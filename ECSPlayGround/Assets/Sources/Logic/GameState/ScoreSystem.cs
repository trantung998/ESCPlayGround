using System;
using System.Collections.Generic;
using Entitas;

public class ScoreFeature : Feature
{
    public ScoreFeature(Contexts contexts) : base("Score Systems")
    {
        Add(new ScoreSystem(contexts));
    }
}
public class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private Contexts context;
    public ScoreSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var currentScore = context.gameState.score.value;
        context.gameState.ReplaceScore(currentScore + entities.Count);
    }

    public void Initialize()
    {
        context.gameState.SetScore(0);
    }
}

