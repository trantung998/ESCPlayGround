using System.Collections.Generic;
using Entitas;

public class CharacterAnimationSystem : ReactiveSystem<GameEntity>
{
    private Contexts contexts;

    public CharacterAnimationSystem(Contexts context) : base(context.game)
    {
        contexts = context;
    }

    protected override void Execute(List<GameEntity> entities)
    {

    }

    protected override bool Filter(GameEntity entity)
    {
        return false;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return null;
    }

    
}