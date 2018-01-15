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
                    GameMatcher.MoveSpeed,
                    GameMatcher.UpdateEffect));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSlowListComponnet && entity.hasPosition && entity.hasMoveSpeed;
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
                        entity.moveSpeed.effectiveValue = entity.moveSpeed.value * slowActive.value;
                        entity.isIsSlowing = true;
                    }
                    else
                    {
                        entity.moveSpeed.ReturnBaseValue();
                        entity.isIsSlowing = false;
                    }
                    entity.ReplaceVelocity(entity.velocity.value.normalized * entity.moveSpeed.effectiveValue);
                }
            });
        }
    }
}