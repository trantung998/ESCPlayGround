using System.Collections.Generic;
using Entitas;


public class PlayerInputDestroySystem : ReactiveSystem<InputEntity>
{
    public PlayerInputDestroySystem(Contexts contexts) : base(contexts.input)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.DestroyPlayerInput);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isDestroyPlayerInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var inputEntity in entities)
        {
            inputEntity.Destroy();
        }
    }
}