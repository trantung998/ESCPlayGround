using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Scripts.Systems
{
    public class AddViewBulletSystem : ReactiveSystem<GameEntity>
    {

        private GameContext gameContext;
        public AddViewBulletSystem(Contexts contexts) : base(contexts.game)
        {
            gameContext = contexts.game;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.GetGroup(GameMatcher.AllOf(GameMatcher.))
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
