using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Systems.Game.Systems
{
    public class PositionReactiveSystem : ReactiveSystem<GameEntity>
    {
        public PositionReactiveSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public PositionReactiveSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}