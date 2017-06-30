using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using Entitas;
using UnityEngine;


public class MovePieceSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext context;

    public MovePieceSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition && entity.hasMove;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var pos = e.position;
            var atTopRow = pos.value.y == context.gameBoard.rows - 1;
            if(atTopRow)
                e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 1);
            e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0), 0.3f);
        }
    }
}

