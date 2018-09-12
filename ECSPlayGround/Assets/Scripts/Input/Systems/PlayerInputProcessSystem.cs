using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Entitas;
using UnityEngine;

public class PlayerInputProcessSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts contexts;
    private readonly InputContext inputContexts;
    private Vector3 touchPosition;


    private GameEntity playerRef;

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
        var input = entities[0];
        if (playerRef == null)
        {
            playerRef = contexts.game.GetEntitiesWithCharacterId("Player1").FirstOrDefault();
        }

        if (playerRef != null)
        {
            if (playerRef.characterState.value != CharacterState.Death)
            {
                touchPosition = input.playerInput.TouchPosition;

                var command = inputContexts.CreateEntity();
                command.AddCharacterMoveCommand(touchPosition);
            }
        }

        input.isDestroyPlayerInput = true;
    }
}