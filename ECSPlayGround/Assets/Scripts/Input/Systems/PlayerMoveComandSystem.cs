using System.Collections.Generic;
using System.Linq;
using Entitas;
using Extensions;
using UnityEngine;

public class PlayerMoveComandSystem : ReactiveSystem<InputEntity>
//    , IExecuteSystem
{
    private readonly InputContext _inputContext;
    private readonly GameContext _gameContext;

    private Vector3 touchPosition;
    private IGroup<InputEntity> _inputs;
    private GameEntity playerRef;
    private Vector2 min;
    private Vector2 max;

    public PlayerMoveComandSystem(Contexts contexts) : base(contexts.input)
    {
        _inputContext = contexts.input;
        _gameContext = contexts.game;

        min = contexts.meta.configurationService.instance.GetCharacterConfigs.botLeft;
        max = contexts.meta.configurationService.instance.GetCharacterConfigs.topRight;
    }

    private void MoveHandler(Vector3 playerPosition, float moveSpeed)
    {
//        touchPosition.x = Mathf.Clamp(touchPosition.x, min.x, max.x);
//        touchPosition.y = Mathf.Clamp(touchPosition.y, min.y, max.y);
//        touchPosition.z = playerPosition.z;

        playerPosition = Vector3.Lerp(playerPosition, touchPosition, Time.deltaTime * moveSpeed);

        playerRef.ReplaceEventsPosition(playerPosition.ToVector2D());
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.CharacterMoveCommand);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasCharacterMoveCommand;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var entity = entities[0];
//        touchPosition = entity.characterMoveCommand.Position;
        if (playerRef == null)
        {
            playerRef = _gameContext.GetEntitiesWithCharacterId("Player1").FirstOrDefault();
        }

        if (playerRef != null)
        {
            MoveHandler(entity.characterMoveCommand.Position, playerRef.characterMoveSpeed.value);
        }

        entity.isDestroyPlayerInput = true;
    }

//    public void Execute()
//    {
//        if (playerRef == null)
//        {
//            playerRef = _gameContext.GetEntitiesWithCharacterId("Player1").FirstOrDefault();
//        }
//
//        if (playerRef != null)
//        {
//            MoveHandler(touchPosition, playerRef.characterMoveSpeed.value);
//        }
//    }
}