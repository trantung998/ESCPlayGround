using Entitas;

public class RegTimeService : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly ITimerService _service;

    public void Initialize()
    {
        _metaContext.ReplaceTimeService(_service);
    }

    public RegTimeService(MetaContext meta, ITimerService timerService)
    {
        _metaContext = meta;
        _service = timerService;
    }
}