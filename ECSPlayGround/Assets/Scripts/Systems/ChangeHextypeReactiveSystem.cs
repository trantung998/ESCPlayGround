using System.Collections.Generic;
using Entitas;

public class ChangeHextypeReactiveSystem : ReactiveSystem<GameEntity>
{
    private GameContext context;
    public ChangeHextypeReactiveSystem(Contexts context) : base(context.game)
    {
        this.context = context.game;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isClickInput 
            && entity.hasPosition 
            && entity.hasClickButtonNumber
            && entity.clickButtonNumber.value == 0;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(
            GameMatcher.ClickInput, 
            GameMatcher.Position,
            GameMatcher.ClickButtonNumber));
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var hexs = context.GetEntitiesWithPosition(entity.position.Value);
            foreach (var hex in hexs)
            {
                if (hex.hasHexagonType)
                {
                    var newType = (int) hex.hexagonType.value;
                    newType += 1;
                    newType %= 5;
                    hex.ReplaceHexagonType((HexagonType)newType);
                }
            }

            entity.Destroy();
        }
    }

}