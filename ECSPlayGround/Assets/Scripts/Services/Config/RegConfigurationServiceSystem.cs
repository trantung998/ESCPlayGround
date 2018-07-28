using Entitas;

public class RegConfigurationServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IConfigurationService _service;

    public void Initialize()
    {
            _metaContext.ReplaceConfigurationService(_service);
    }

    public RegConfigurationServiceSystem(MetaContext metaContext, IConfigurationService inputService)
    {
        _metaContext = metaContext;
        _service = inputService;
    }
}