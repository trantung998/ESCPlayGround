using System.Collections.Generic;
using Entitas;
using Sources.GamePlay.Player.Scripts;
using UnityEngine;

namespace Sources.GamePlay.Player.System
{
    public class CooldownControlSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> cooldownEntities;
        
        public CooldownControlSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
            cooldownEntities = _gameContext.GetGroup(GameMatcher.Cooldown);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Tick);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTick;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var coodownEntities = cooldownEntities.GetEntities();
            var tickValue = _gameContext.gameplayData.value.tickInverter;
            foreach (var coodownEntity in coodownEntities)
            {
                TickPassed(coodownEntity.cooldown.SkillCooldownList, tickValue);
            }
        }
        
        
        public void TickPassed(List<SkillCooldownElement> SkillCooldownList, float tickTime = 0.1f)
        {
            SkillCooldownList.ForEach(element => element.time -= tickTime);
            SkillCooldownList.RemoveAll(element => element.time <= 0);
        }
    }
}