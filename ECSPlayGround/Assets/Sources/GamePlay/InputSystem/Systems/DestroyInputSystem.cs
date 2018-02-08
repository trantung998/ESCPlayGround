using System.Collections.Generic;
using Entitas;

public class DestroyInputSystem : ReactiveSystem<InputEntity>
{
    private Contexts contexts;

    public DestroyInputSystem(Contexts context) : base(context.input)
    {
        contexts = context;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isInputDestroy;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.InputDestroy);
    }

    
}