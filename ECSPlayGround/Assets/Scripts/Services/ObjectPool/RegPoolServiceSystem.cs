using Entitas;

public class RegPoolServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IPoolService _service;

    public void Initialize()
    {
        _metaContext.ReplacePoolService(_service);
    }

    public RegPoolServiceSystem(MetaContext metaContext, IPoolService inputService)
    {
        _metaContext = metaContext;
        _service = inputService;
    }
}