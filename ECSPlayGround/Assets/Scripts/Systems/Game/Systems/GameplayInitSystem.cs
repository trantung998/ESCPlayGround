using Entitas;
using Entitas.Unity;
using Extensions;

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
        player.AddCharacterMoveSpeed(_configurationService.GetCharacterConfigs.MoveSpeed);
        player.AddEventsPosition(_configurationService.GetCharacterConfigs.RespawnPosition.ToVector2D());
        player.AddAsset(_configurationService.GetCharacterConfigs.characterPrefabPath);
        player.AddCharacterState(CharacterState.Normal);

        _gameContext.SetCharacterRef(player);
    }
}