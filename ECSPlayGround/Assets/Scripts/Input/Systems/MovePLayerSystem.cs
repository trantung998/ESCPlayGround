using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MovePlayerSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts contexts;
    private Vector3 touchPosition;
    public MovePlayerSystem(Contexts contexts) : base(contexts.input)
    {
    }

    public MovePlayerSystem(ICollector<InputEntity> collector) : base(collector)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(InputEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<InputEntity> entities)
    {

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
}