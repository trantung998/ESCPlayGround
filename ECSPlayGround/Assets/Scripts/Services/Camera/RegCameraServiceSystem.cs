using Entitas;

public class RegCameraServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly ICameraService _service;

    public void Initialize()
    {
        _metaContext.ReplaceCameraService(_service);
    }

    public RegCameraServiceSystem(MetaContext metaContext, ICameraService service)
    {
        _metaContext = metaContext;
        _service = service;
    }
}