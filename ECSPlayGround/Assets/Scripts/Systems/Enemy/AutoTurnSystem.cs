using System.Collections.Generic;
using Entitas;

public class AutoTurnSystem : ReactiveSystem<GameEntity>
{
    public AutoTurnSystem(Contexts context) : base(context.game)
    {
        
    }


    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(
            GameMatcher.AutoHorizontalMove,
            GameMatcher.HitBound, 
            GameMatcher.Position, 
            GameMatcher.Velocity));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasVelocity && entity.isHitBound;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.ReplaceVelocity(entity.velocity.value * -1);
            entity.isHitBound = false;
        }
    }
}