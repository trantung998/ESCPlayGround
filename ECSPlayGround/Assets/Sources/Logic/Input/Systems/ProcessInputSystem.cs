using System.Collections.Generic;
using Entitas;

    public sealed class ProcessInputSystem : ReactiveSystem<InputEntity>
    {
        private readonly Contexts _contexts;

        public ProcessInputSystem(Contexts contexts) : base(contexts.input)
        {
            _contexts = contexts;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.Input);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInput;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var inputEntity = entities.SingleEntity();
            var input = inputEntity.input;
            //Todo: remove comment


//            foreach (var e in _contexts.game.GetEntitiesWithPosition(new IntVector2(input.x, input.y)).Where(e => e.isInteractive))
//            {
//                e.isDestroyed = true;
//            }
        }
    }

