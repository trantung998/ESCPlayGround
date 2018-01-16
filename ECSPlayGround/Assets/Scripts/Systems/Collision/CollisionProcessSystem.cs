using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Sources.Formular;

namespace Systems.Collision
{
    public class CollisionProcessSystem : ReactiveSystem<GameEntity>  , ICleanupSystem
    {
        private GameContext gameContext;
        private IGroup<GameEntity> cleanupEntity;
        public CollisionProcessSystem(Contexts contexts) : base(contexts.game)
        {
            this.gameContext = contexts.game;
            cleanupEntity = gameContext.GetGroup(GameMatcher.Collision);
        }
         
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collision.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCollision;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var target = entity.collision.target as GameEntity;
                var self = entity.collision.selft as GameEntity;
                if (target != null)
                {
                    if (self.hasDamage)
                    {
                        target.AddOnTakeDamage(self.damage);
                    }

                    if (self.hasEffect)
                    {
                        var effectList = self.effect.effects;
                        target.isUpdateEffect = false;
                        effectList.ForEach(data =>
                        {
                            switch (data.type)
                            {
                                case EffectType.Slow:
                                    if (!target.hasSlowListComponnet)
                                    {
                                        target.AddSlowListComponnet(new List<EffectData>());
                                    }
                                    target.slowListComponnet.AddEffectData(data);
                                    break;
                                case EffectType.Stun:
                                    break;
                            }
                        });
                        target.isUpdateEffect = true;
                    }
                }
                self.isDestroyed = true;
            }
        }
        
        public void Cleanup()
        {
            foreach (var entity in cleanupEntity.GetEntities())
            {
                entity.Destroy();
            }
        }
    }
}
