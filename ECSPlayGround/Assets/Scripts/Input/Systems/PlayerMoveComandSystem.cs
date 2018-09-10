using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class PlayerMoveComandSystem : IExecuteSystem, ICleanupSystem
{
    private readonly InputContext _inputContext;
    private Vector3 touchPosition;
    private IGroup<InputEntity> _inputs;
    private GameEntity playerRef;
    private Vector2 min;
    private Vector2 max;

    public PlayerMoveComandSystem(Contexts contexts)
    {
        _inputContext = contexts.input;
        _inputs = _inputContext.GetGroup(InputMatcher.CharacterMoveCommand);
        playerRef = contexts.game.characterRef.value;

        min = contexts.meta.configurationService.instance.GetCharacterConfigs.botLeft;
        max = contexts.meta.configurationService.instance.GetCharacterConfigs.topRight;
    }

    private void MoveHandler(Vector3 playerPosition, float moveSpeed)
    {
        touchPosition.x = Mathf.Clamp(touchPosition.x, min.x, max.x);
        touchPosition.y = Mathf.Clamp(touchPosition.y, min.y, max.y);
        touchPosition.z = playerPosition.z;

        playerPosition = Vector3.Lerp(playerPosition, touchPosition, Time.deltaTime * moveSpeed);

        playerRef.ReplaceCharacterPosition(playerPosition);
    }

    private readonly List<InputEntity> _buffer = new List<InputEntity>();

    public void Cleanup()
    {
        foreach (var inputEntity in _inputs.GetEntities(_buffer))
        {
            inputEntity.Destroy();
        }
    }

    public void Execute()
    {
        if (_inputs.count > 0)
        {
            touchPosition = _inputs.GetEntities(_buffer)[0].characterMoveCommand.Position;
        }

        MoveHandler(playerRef.characterPosition.value, playerRef.characterMoveSpeed.value);
    }
}