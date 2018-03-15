using System.Collections.Generic;
using Entitas;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class PlayerAttkProcessSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> characters;
        public PlayerAttkProcessSystem(Contexts contexts) : base(contexts.input)
        {
            characters = contexts.game.GetGroup(GameMatcher.CharacterControl);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool Filter(InputEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<InputEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}