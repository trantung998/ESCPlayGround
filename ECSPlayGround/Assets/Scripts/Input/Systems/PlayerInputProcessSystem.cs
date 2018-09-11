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

    private GameEntity playerRef;
    
    public PlayerInputProcessSystem(Contexts contexts) : base(contexts.input)
    {
        this.contexts = contexts;
        inputContexts = contexts.input;

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

        if (playerRef.characterState.value != CharacterState.Death)
        {
            touchPosition = input.playerInput.TouchPosition;

            var command = inputContexts.CreateEntity();

            command.characterMoveCommand.Position = touchPosition;
        }
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