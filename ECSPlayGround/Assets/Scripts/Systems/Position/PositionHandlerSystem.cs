
using System.Collections.Generic;
using System.Diagnostics;
using Entitas;
using Debug = UnityEngine.Debug;

public class PositionHandlerSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    public PositionHandlerSystem(Contexts ctx) : base(ctx.game)
    {
        contexts = ctx;
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
    }
}