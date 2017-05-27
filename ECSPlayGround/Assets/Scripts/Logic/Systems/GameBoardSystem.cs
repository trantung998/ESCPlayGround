//using System.Collections.Generic;
//using Entitas;
//
//namespace Logic.Systems
//{
//    public class GameBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
//    {
//        private GameContext context;
//        private IGroup<GameEntity> gameBoardElements;
//
//        public GameBoardSystem(Contexts contexts) : base(contexts.game)
//        {
//            this.context = contexts.game;
//            //gameBoardElements = context.GetGroup();
//        }
//
//        public GameBoardSystem(Collector<GameEntity> collector) : base(collector)
//        {
//        }
//
//        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
//        {
//            throw new System.NotImplementedException();
//        }
//
//        protected override bool Filter(GameEntity entity)
//        {
//            throw new System.NotImplementedException();
//        }
//
//        protected override void Execute(List<GameEntity> entities)
//        {
//            throw new System.NotImplementedException();
//        }
//
//        public void Initialize()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
