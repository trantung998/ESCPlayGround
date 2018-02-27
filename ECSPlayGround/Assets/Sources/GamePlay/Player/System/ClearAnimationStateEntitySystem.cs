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
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.CharacterState, GameMatcher.PlayerId));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new global::System.NotImplementedException();
        }
    }
}