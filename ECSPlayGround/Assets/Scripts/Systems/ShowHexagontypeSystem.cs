using System.Collections.Generic;
using Entitas;

public class ShowHexagontypeSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;
    public ShowHexagontypeSystem(Contexts context) : base(context.game)
    {
        contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.value.GetComponent<HexagonTypeView>().ShowType(entity.hexagonType.value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasHexagonType;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.HexagonType);
    }

    
}