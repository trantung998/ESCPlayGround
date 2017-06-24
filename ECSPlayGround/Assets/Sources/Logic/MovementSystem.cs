using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;


    public class MovementSystem : IExecuteSystem, ICleanupSystem
    {
        private readonly IGroup<GameEntity> _moves;
        private readonly IGroup<GameEntity> _moveCompletes;
        private float speed = 4.0f;
        public MovementSystem(Contexts contexts)
        {
            _moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
            _moves = contexts.game.GetGroup(GameMatcher.Move);
        }

        public void Execute()
        {
            foreach (var e in _moves.GetEntities())
            {
                Vector2 dir = e.move.target - e.position.value;
                Vector2 newPosition = e.position.value + dir.normalized*speed*Time.deltaTime;
                e.ReplacePosition(newPosition);

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                e.ReplaceDirection(angle);

                float dist = dir.magnitude;
                if (dist <= 0.5f)
                {
                    e.RemoveMove();
                    e.isMoveComplete = true;
                }
            }
        }

        public void Cleanup()
        {
            foreach (var e in _moveCompletes.GetEntities())
            {
                e.isMoveComplete = false;
            }
        }
    }

public class MovementFeatute : Feature
{
    public MovementFeatute(Contexts contexts) : base("Movement Systems")
    {
        Add(new MovementSystem(contexts));
    }
}
