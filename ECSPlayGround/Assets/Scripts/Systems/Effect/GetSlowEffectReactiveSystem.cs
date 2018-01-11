using System.Collections.Generic;
using Entitas;

namespace Assets.Scripts.Systems.Effect
{
    public class GetSlowEffectReactiveSystem : ReactiveSystem<GameEntity>
    {
        private GameContext gameContext;
        
        public GetSlowEffectReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.EffectSlow, GameMatcher.Position));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasEffectSlow && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            entities.ForEach(entity =>
            {
                
            });
        }
    }
}