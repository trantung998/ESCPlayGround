using System.Collections.Generic;
using Entitas;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class MoveInputProcessSystem : ReactiveSystem<InputEntity>, ICleanupSystem
    {
        public MoveInputProcessSystem(IContext<InputEntity> context) : base(context)
        {
        }

        public MoveInputProcessSystem(ICollector<InputEntity> collector) : base(collector)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.MoveInput);
        }

        protected override bool Filter(InputEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<InputEntity> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Cleanup()
        {
            throw new System.NotImplementedException();
        }
    }
}