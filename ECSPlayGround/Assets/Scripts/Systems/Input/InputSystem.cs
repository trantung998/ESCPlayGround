using Entitas;
using Entitas.Utils;
using UnityEngine;

public class InputSystem : IExecuteSystem, ICleanupSystem
{
    private IGroup<InputEntity> moveInputs;
    private IGroup<InputEntity> atkInputs;
    private Contexts contexts;

    public InputSystem(Contexts ctx)
    {
        this.contexts = ctx;
        moveInputs = contexts.input.GetGroup(InputMatcher.MoveInput);
        atkInputs = contexts.input.GetGroup(InputMatcher.PlayerAttackInput);
            
    }

    public void Execute()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        contexts.input.CreateEntity()
            .AddMoveInput(new Vector3(moveX, moveY));

        if (Input.GetButton("Fire1"))
        {
            contexts.input.CreateEntity()
                .isPlayerAttackInput = true;
        }
    }

    public void Cleanup()
    {
        foreach (var input in atkInputs.GetEntities())
        {
            input.Destroy();
        }

        foreach (var input in moveInputs.GetEntities())
        {
            input.Destroy();
        }
    }
}

