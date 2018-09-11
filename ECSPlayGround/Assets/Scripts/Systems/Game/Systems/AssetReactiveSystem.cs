using System.Collections.Generic;
using Entitas;

namespace Systems.Game.Systems
{
    public class AssetReactiveSystem : ReactiveSystem<GameEntity>
    {
        private IViewService _viewService;
        private Contexts _contexts;

        public AssetReactiveSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _viewService = contexts.meta.viewService.instance;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Asset);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAsset;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                _viewService.CreateView(_contexts, gameEntity, gameEntity.asset.assetPath, true);
            }
        }
    }
}