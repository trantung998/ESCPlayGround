using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;


   public class RenderPositionSystem :ReactiveSystem<GameEntity>
    {
       public RenderPositionSystem(Contexts context) : base(context.game)
       {
       }

       public RenderPositionSystem(ICollector<GameEntity> collector) : base(collector)
       {
       }

       protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
       {
           return context.CreateCollector(GameMatcher.Position);
       }

       protected override bool Filter(GameEntity entity)
       {
           return entity.hasView && entity.hasPosition;
       }

       protected override void Execute(List<GameEntity> entities)
       {
           foreach (var e in entities)
           {
               e.view.gameObject.transform.position = e.position.value;
           }
       }
    }

