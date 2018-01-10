using System.Collections.Generic;
using Entitas;
using Sources.Formular;

namespace Systems.Collision
{
    public class DamageProcessSystem : ReactiveSystem<GameEntity>, ICleanupSystem
    {
        private GameContext _context;
        private IGroup<GameEntity> cleanupEntity;
        
        public DamageProcessSystem(Contexts context) : base(context.game)
        {
            _context = context.game;
            cleanupEntity = _context.GetGroup(GameMatcher.OnTakeDamage);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.OnTakeDamage);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHealth && entity.hasOnTakeDamage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                //todo : Logic gây damage
                if (entity.hasHealth)
                {
                    var armor = entity.hasArmor ? entity.armor.value : 0;
                            
                    var newHealth = entity.health.value -
                                    CharacterFormulars.CalculateDamage(entity.onTakeDamage.damageValue.value, armor);
                    entity.ReplaceHealth(newHealth);
                }
            }
        }

        public void Cleanup()
        {
            foreach (var entity in cleanupEntity.GetEntities())
            {
                entity.RemoveOnTakeDamage();
            }
        }
    }
}