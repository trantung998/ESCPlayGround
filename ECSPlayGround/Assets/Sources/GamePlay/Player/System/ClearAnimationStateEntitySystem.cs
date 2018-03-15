using System.Collections.Generic;
using Entitas;

namespace Sources.GamePlay.Player.System
{
    public class ClearAnimationStateEntitySystem : ReactiveSystem<GameEntity>
    {
        public ClearAnimationStateEntitySystem(Contexts contexts) : base(contexts.game)
        {
        }        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.AnimationControl, GameMatcher.Clean));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isAnimationControl && entity.isClean;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.Destroy();
            }
        }
    }
}