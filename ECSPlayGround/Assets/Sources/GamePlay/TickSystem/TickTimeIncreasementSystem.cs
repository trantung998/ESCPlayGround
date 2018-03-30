using System.Collections.Generic;
using Entitas;

public class TickTimeIncreasementSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;
    private GameContext gameContext;
    
    public TickTimeIncreasementSystem(Contexts context) : base(context.game)
    {
        contexts = context;
        gameContext = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var detatime = entities.SingleEntity().deltaTime.value;
        var tickTime = gameContext.tickTime.currentTick;
        tickTime += detatime;
        
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DeltaTime);
    }

    
}