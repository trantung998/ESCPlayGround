using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;


public class RenderDirectionSystem :ReactiveSystem<GameEntity>
    {
        public RenderDirectionSystem(Contexts context) : base(context.game)
        {
        }

        public RenderDirectionSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Direction);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDirection && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                float ang = e.direction.value;
                e.view.gameObject.transform.rotation = Quaternion.AngleAxis(ang - 90, Vector3.forward);
            }
        }
    }

