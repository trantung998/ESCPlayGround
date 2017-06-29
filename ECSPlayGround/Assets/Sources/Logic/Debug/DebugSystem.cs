using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Sources.Logic.Debug
{
    public sealed class DebugSystem : ReactiveSystem<GameEntity>
    {
        public DebugSystem(Contexts contexts) : base(contexts.game)
        {
        }

        public DebugSystem(Collector<GameEntity> collector) : base(collector)
        {
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DebugMessage);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDebugMessage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnityEngine.Debug.Log(entity.debugMessage);
            }
        }
    }
}
