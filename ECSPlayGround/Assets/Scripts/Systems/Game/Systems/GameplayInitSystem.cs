using Entitas;

namespace Systems.Game.Systems
{
    public class GameplayInitSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly IConfigurationService _configurationService;

        public GameplayInitSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _configurationService = contexts.meta.configurationService.instance;
        }

        public void Initialize()
        {
            var player = _gameContext.CreateEntity();
            player.AddCharacterId("Player1");
            player.AddCharacterMoveSpeed(_configurationService.GetPlayerMovementConfigs.MoveSpeed);
            player.AddCharacterPosition(_configurationService.GetPlayerMovementConfigs.RespawnPosition);
        }
    }
}