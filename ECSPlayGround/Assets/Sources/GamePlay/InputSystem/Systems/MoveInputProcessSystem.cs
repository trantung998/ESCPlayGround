using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class MoveInputProcessSystem : ReactiveSystem<InputEntity>, ICleanupSystem
    {
        private IGroup<InputEntity> moveInputs;
        private GameContext gameContext;

        private string currentPlayerId;
        
        public MoveInputProcessSystem(Contexts contexts) : base(contexts.input)
        {
            gameContext = contexts.game;
            moveInputs = contexts.input.GetGroup(InputMatcher.MoveInput);
        }
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
            var currentPlayerEntity = gameContext.GetEntitiesWithPlayerId("").ToArray()[0];
        }

        public void Cleanup()
        {
            foreach (var inputEntity in moveInputs)
            {
                inputEntity.Destroy();
            }
        }
    }
}