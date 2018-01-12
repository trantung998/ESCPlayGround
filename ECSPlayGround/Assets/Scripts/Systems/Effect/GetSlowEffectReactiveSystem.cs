using System.Collections.Generic;
using Entitas;
using UnityEngine;

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
            return context.CreateCollector(
                GameMatcher.AllOf(
                    GameMatcher.SlowListComponnet, 
//                    GameMatcher.Position, 
                    GameMatcher.UpdateEffect));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSlowListComponnet && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Debug.Log("GetSlowEffectReactiveSystem trigger");
            entities.ForEach(entity =>
            {
                if (entity.hasSlowListComponnet)
                {
                    if (entity.slowListComponnet.listEffect.Count > 0)
                    {
                        var slowActive = entity.slowListComponnet.GetActiveEffect();
                        var vel = entity.effectiveVelocity.value * slowActive.value;
                        entity.ReplaceEffectiveVelocity(vel);
                    }
                    else
                    {
                        entity.ReplaceEffectiveVelocity(entity.velocity.value);
                    }
                }
            });
        }
    }
}