using System.Collections.Generic;
using Entitas;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class PlayerAttkProcessSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> characters;
        private readonly GameContext gameContext;
        
        public PlayerAttkProcessSystem(Contexts contexts) : base(contexts.input)
        {
            characters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.CharacterControl));
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
            foreach (var inputEntity in entities)
            {
                var changeAnimationEntity = gameContext.CreateEntity();
                changeAnimationEntity.isAnimationControl = true;
                changeAnimationEntity.AddPlayerId(inputEntity.atkInput.playerId);
                changeAnimationEntity.AddCharacterState(PlayerAnimationState.Atk);
                //clear
                inputEntity.isInputDestroy = true;
            }
        }
    }
}