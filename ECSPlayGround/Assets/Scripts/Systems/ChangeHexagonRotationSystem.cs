using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ChangeHexagonRotationSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;

    public ChangeHexagonRotationSystem(Contexts context) : base(context.game)
    {
        contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var angle = entity.hexagonRotation.value * 60f;
            entity.view.value.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHexagonRotation && entity.hasView;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.HexagonRotation);
    }

    
}