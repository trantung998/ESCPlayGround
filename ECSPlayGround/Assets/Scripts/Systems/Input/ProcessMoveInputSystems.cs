using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Scripts.Systems.Input
{
    public class ProcessMoveInputSystems : ReactiveSystem<InputEntity>
    {
        public ProcessMoveInputSystems(ICollector<InputEntity> collector) : base(collector)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            throw new NotImplementedException();
        }

        protected override bool Filter(InputEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<InputEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
