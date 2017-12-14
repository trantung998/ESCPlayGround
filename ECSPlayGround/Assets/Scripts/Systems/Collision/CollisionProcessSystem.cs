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
            return context.CreateCollector(GameMatcher.Collision);
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
                if (target != null)
                {
                    var self = entity.collision.selft as GameEntity;
                    if (self.hasDamage)
                    {
                        //todo : Logic gây damage
                        if (target.hasHealth)
                        {
                            var armor = target.hasArmor ? target.armor.value : 0;
                            var newHealth = target.health.value -
                                            CharacterFormulars.CalculateDamage(target.health.value, armor);
                            target.ReplaceHealth(newHealth);
                        }
                    }
                }
            }
        }

        public void Cleanup()
        {
            foreach (var entity in cleanupEntity.GetEntities())
            {
//                entity.Destroy();
            }
        }
    }
}
