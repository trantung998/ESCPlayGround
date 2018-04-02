using System.Collections.Generic;
using System.Linq;
using Entitas;
using Sources.GamePlay.Player.Scripts;
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
                var character = inputEntity.atkInput.playerId;
                var skillId = inputEntity.atkInput.id;
                var characterEntitySet = gameContext.GetEntitiesWithPlayerId(character);
                if (characterEntitySet != null && characterEntitySet.Count > 0)
                {
                    var characterEntity = characterEntitySet.ToList()[0];
                    var skillCooldownList = characterEntity.cooldown.SkillCooldownList;
                    if (!characterEntity.cooldown.IsContain(skillId))
                    {                        
                        var changeAnimationEntity = gameContext.CreateEntity();
                        changeAnimationEntity.isAnimationControl = true;
                        changeAnimationEntity.AddPlayerId(inputEntity.atkInput.playerId);
                        //TODO : KHI CAST SKILL NAO THI SET DUNG STATE CỦA SKILL DO
                        changeAnimationEntity.AddCharacterFiniteState(CharacterFiniteState.Atk);
                        
                        skillCooldownList.Add(new SkillCooldownElement(){id = skillId, time = 1.1f});
                        characterEntity.ReplaceCooldown(skillCooldownList);
                    }
                }
                //clear
                inputEntity.isInputDestroy = true;
            }
        }
    }
}