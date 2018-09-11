using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Systems.Game.Systems
{
    public class PositionReactiveSystem : ReactiveSystem<GameEntity>
    {
        public PositionReactiveSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CharacterPosition);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCharacterPosition && entity.hasCharacterGameobject;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            //Transform service?
            foreach (var gameEntity in entities)
            {
                gameEntity.characterGameobject.value.transform.position = gameEntity.characterPosition.value;
            }
        }
    }
}