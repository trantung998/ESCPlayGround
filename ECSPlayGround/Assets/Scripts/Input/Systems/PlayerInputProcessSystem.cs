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
    public PlayerInputProcessSystem(Contexts contexts) : base(contexts.input)
    {
        this.contexts = contexts;
        inputContexts = contexts.input;
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
//        var input = entities.SingleEntity();
//        var player = contexts.game.GetEntitiesWithCharacterType(CharacterType.Player).First(entity => entity.characterId.value == "");
//        if (player.characterState.value != CharacterState.Death)
//        {
//            var command = inputContexts.CreateEntity();
//            command.characterMove
//        }
    }

    private void MoveHandler(Transform transform, Vector2 min, Vector2 max, float moveSpeed, float stopMove)
    {
        touchPosition.x = Mathf.Clamp(touchPosition.x, min.x, max.x);
        touchPosition.y = Mathf.Clamp(touchPosition.y, min.y, max.y);
        touchPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * moveSpeed);

//        if (transform.position.x - touchPosition.x < -stopMove)
//        {
//            characterMoveStates.ChangeState(CharacterState.TurningRight);
//        }
//        else if (transform.position.x - touchPosition.x > stopMove)
//        {
//            characterMoveStates.ChangeState(CharacterState.TurningLeft);
//        }
    }

    public void Cleanup()
    {
        
    }
}