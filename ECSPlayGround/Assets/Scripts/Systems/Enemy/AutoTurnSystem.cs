using System.Collections.Generic;
using Entitas;

public class AutoTurnSystem : ReactiveSystem<GameEntity>
{
    public AutoTurnSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public AutoTurnSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.HitBound, GameMatcher.Position, GameMatcher.Velocity));
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }
}