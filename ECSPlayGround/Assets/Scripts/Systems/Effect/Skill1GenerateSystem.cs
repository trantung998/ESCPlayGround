using System.Collections.Generic;
using Entitas;
public class Skill1GenerateSystem : ReactiveSystem<InputEntity>
{
    private InputContext inputContext;
    private IGroup<GameEntity> player;
    
    public Skill1GenerateSystem(Contexts contexts) : base(contexts.input)
    {
        inputContext = contexts.input;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(InputEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<InputEntity> entities)
    {
        throw new System.NotImplementedException();
    }
}
