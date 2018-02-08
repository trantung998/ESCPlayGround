using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FacingReactiveSystem : 
    ReactiveSystem<GameEntity>
{
    private Contexts contexts;

    public FacingReactiveSystem(Contexts context) : base(context.game)
    {
        contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.facingDirection.value == FacingDirection.Right)
            {
                if (entity.characterControl.value.Rigidbody.rotation.eulerAngles != Vector3.zero)
                {
                    entity.characterControl.value.Rigidbody.MoveRotation(Quaternion.AngleAxis(0, Vector3.up));
                }
            }
            else
            {
                if (entity.characterControl.value.Rigidbody.rotation.eulerAngles == Vector3.zero)
                {
                    entity.characterControl.value.Rigidbody.MoveRotation(Quaternion.AngleAxis(180, Vector3.up));
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterControl && entity.hasFacingDirection;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.FacingDirection);
    }
}