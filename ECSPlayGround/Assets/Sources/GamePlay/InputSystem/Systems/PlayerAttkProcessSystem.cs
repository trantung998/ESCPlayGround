using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class PlayerAttkProcessSystem : ReactiveSystem<InputEntity>
    {
        private readonly GameContext gameContext;
        
        public PlayerAttkProcessSystem(Contexts contexts) : base(contexts.input)
        {
            gameContext = contexts.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.AtkInput);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasAtkInput;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                var changeAnimationEntity = gameContext.CreateEntity();
                changeAnimationEntity.isAnimationControl = true;
                changeAnimationEntity.AddPlayerId(inputEntity.atkInput.playerId);
                changeAnimationEntity.AddCharacterFiniteState(CharacterFiniteState.Atk);
                //clear
                inputEntity.isInputDestroy = true;
            }
        }
    }
}