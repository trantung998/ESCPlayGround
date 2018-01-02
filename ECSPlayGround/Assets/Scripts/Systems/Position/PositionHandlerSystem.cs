
using System.Collections.Generic;
using System.Diagnostics;
using Entitas;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PositionHandlerSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    private MoveBound _moveBound;
    
    public PositionHandlerSystem(Contexts ctx) : base(ctx.game)
    {
        contexts = ctx;
        _moveBound = contexts.game.mapConfigs.value.moveBound;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasVelocity;
    }

    protected override void Execute(List<GameEntity> entities)
    {
//        Debug.Log("Position change");
        foreach (var entity in entities)
        {
            var transform = entity.view.value.transform;
            var pos = entity.position.value;
            if (entity.isAutoHorizontalMove)
            {
                if (pos.x < _moveBound.left
                    || pos.x > _moveBound.right
                    || pos.z > _moveBound.top
                    || pos.z < _moveBound.bottom)
                {
                    entity.isHitBound = true;
                }
            }
            transform.localPosition = pos;
            
            
 
        }
    }
}