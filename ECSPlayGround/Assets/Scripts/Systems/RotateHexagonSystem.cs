using System.Collections.Generic;
using Entitas;

public class RotateHexagonSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;

    public RotateHexagonSystem(Contexts context) : base(context.game)
    {
        contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var hexs = contexts.game.GetEntitiesWithPosition(entity.position.Value);
            foreach (var hex in hexs)
            {
                if (hex.hasHexagonRotation)
                {
                    var newRoration = hex.hexagonRotation.value;
                    newRoration += 1;
                    newRoration %= 6;
                    hex.ReplaceHexagonRotation(newRoration);
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasClickButtonNumber && entity.clickButtonNumber.value == 1;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.ClickButtonNumber, GameMatcher.ClickInput, GameMatcher.Position));
    }



    
}