using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;


    public class EntityCreatorSystem : ReactiveSystem<InputEntity>
    {
        private GameContext _gameContext;
        public EntityCreatorSystem(Contexts context) : base(context.input)
        {
            _gameContext = context.game;
        }

        public EntityCreatorSystem(ICollector<InputEntity> collector) : base(collector)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasMouseDown;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
