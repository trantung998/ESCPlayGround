using System.Collections.Generic;
using Entitas;

namespace Systems.Collision
{
    public class DamageProcessSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;
        
        public DamageProcessSystem(Contexts context) : base(context.game)
        {
            _context = context.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}