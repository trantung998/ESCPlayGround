//using Entitas;
//
//namespace Systems
//{
//    public class CleanUpDebugMessageSystem : ICleanupSystem
//    {
//        readonly GameContext _context;
//        readonly IGroup<GameEntity> _debugMessages;
//
//        public CleanUpDebugMessageSystem(GameContext context)
//        {
//            _context = context;
//
//            _debugMessages = _context.GetGroup(GameMatcher.DebugMessage);
//        }
//
//        public void Cleanup()
//        {
//            // group.GetEntities() always gives us an up to date list
//            foreach (var e in _debugMessages.GetEntities())
//            {
//                _context.DestroyEntity(e);
//            }
//        }
//    }
//}
