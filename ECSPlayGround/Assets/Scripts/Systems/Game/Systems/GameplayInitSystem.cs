using Entitas;
using Entitas.Unity;

public class GameplayInitSystem : IInitializeSystem
{
    private readonly GameContext _gameContext;
    private readonly IConfigurationService _configurationService;
    private readonly IPoolService _poolService;

    public GameplayInitSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _configurationService = contexts.meta.configurationService.instance;
        _poolService = contexts.meta.poolService.instance;
    }

    public void Initialize()
    {
        var player = _gameContext.CreateEntity();
        player.AddCharacterId("Player1");
        player.AddCharacterMoveSpeed(_configurationService.GetCharacterConfigs.MoveSpeed);
        player.AddCharacterPosition(_configurationService.GetCharacterConfigs.RespawnPosition);

        var playerGameObject = _poolService.Spawn(_configurationService.GetCharacterConfigs.characterPrefab);

        playerGameObject.gameObject.Link(player, _gameContext);

        player.AddCharacterGameobject(playerGameObject.gameObject);
    }
}