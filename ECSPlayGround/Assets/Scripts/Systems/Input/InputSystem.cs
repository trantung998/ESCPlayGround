using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem, ICleanupSystem
{
    private IGroup<InputEntity> moveInputs;
    private IGroup<InputEntity> cooldown;

    private Contexts contexts;

    private PlayerDataModel _dataModel;

    public InputSystem(Contexts ctx)
    {
        this.contexts = ctx;
        moveInputs = contexts.input.GetGroup(InputMatcher.MoveInput);
        cooldown = contexts.input.GetGroup(InputMatcher.Coolddown);
        _dataModel = contexts.game.playerData.value;
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
            if (!IsContainInput("Fire1"))
            {
                var bulletCooldown = _dataModel.fireRate;
                var atkInput = contexts.input.CreateEntity();
                atkInput.isPlayerAttackInput = true;
                atkInput.AddCoolddown("Fire1", bulletCooldown);           
            }
        }
    }

    private bool IsContainInput(string id)
    {
        foreach (var entity in cooldown.GetEntities())
        {
            if (entity.coolddown.id == id) return true;
        }
        return false;
    }

    public void Cleanup()
    {
        foreach (var input in moveInputs.GetEntities())
        {
            input.Destroy();
        }
    }
}

