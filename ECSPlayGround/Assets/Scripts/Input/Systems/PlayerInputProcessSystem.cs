using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Entitas;
using UnityEngine;

public class PlayerInputProcessSystem : ReactiveSystem<InputEntity>, ICleanupSystem
{
    private readonly Contexts contexts;
    private readonly InputContext inputContexts;
    private Vector3 touchPosition;

    private IGroup<InputEntity> _inputs;

    private Vector2 min;
    private Vector2 max;
    private readonly Vector2 VIEW_PORT_LEFT_BOTTOM = new Vector2(0, 0);
    private readonly Vector2 VIEW_PORT_RIGHT_TOP = new Vector2(1, 1);

    public PlayerInputProcessSystem(Contexts contexts) : base(contexts.input)
    {
        this.contexts = contexts;
        inputContexts = contexts.input;

        min = contexts.meta.cameraService.instance.MainCameraViewportToWorldPoint(VIEW_PORT_LEFT_BOTTOM);
        max = contexts.meta.cameraService.instance.MainCameraViewportToWorldPoint(VIEW_PORT_RIGHT_TOP);

        _inputs = contexts.input.GetGroup(InputMatcher.PlayerInput);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PlayerInput);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasPlayerInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var input = entities.SingleEntity();
        var player = contexts.game.GetEntitiesWithCharacterType(CharacterType.Player)
            .First(entity => entity.characterId.value == "");
        if (player.characterState.value != CharacterState.Death)
        {
            touchPosition = input.playerInput.TouchPosition;
            touchPosition.x = Mathf.Clamp(touchPosition.x, min.x, max.x);
            touchPosition.y = Mathf.Clamp(touchPosition.y, min.y, max.y);

            var currentPos = player.characterPosition.value;
            var moveSpeed = player.characterMoveSpeed.value;

            var command = inputContexts.CreateEntity();

            command.characterMoveCommand.Position = 
                Vector3.Lerp(currentPos, touchPosition, Time.deltaTime * moveSpeed);;
        }
    }

    private void MoveHandler(Transform transform, Vector2 min, Vector2 max, float moveSpeed, float stopMove)
    {
        touchPosition.x = Mathf.Clamp(touchPosition.x, min.x, max.x);
        touchPosition.y = Mathf.Clamp(touchPosition.y, min.y, max.y);
        touchPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * moveSpeed);
    }

    private readonly List<InputEntity> _buffer = new List<InputEntity>();

    public void Cleanup()
    {
        foreach (var entity in _inputs.GetEntities(_buffer))
        {
            entity.Destroy();
        }
    }
}