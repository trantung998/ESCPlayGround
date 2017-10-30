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
        var positionVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //if (positionVector != Vector3.zero)
        {
            var moveInputEntity = contexts.input.CreateEntity();
            moveInputEntity.AddPlayerId("Player1");
            moveInputEntity.AddMoveInput("Player1", positionVector);
        }

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

