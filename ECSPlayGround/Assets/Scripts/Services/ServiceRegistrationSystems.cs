using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;


public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services) : base("Services")
    {
        Add(new RegisterInputServiceSystem(contexts.meta, services.Input));
        Add(new RegViewServiceSystem(contexts.meta, services.View));
        Add(new RegPoolServiceSystem(contexts.meta, services.Pool));
        Add(new RegConfigurationServiceSystem(contexts.meta, services.GameConfig));
        Add(new RegCameraServiceSystem(contexts.meta, services.Camera));
        Add(new RegTimeService(contexts.meta, services.Time));
    }

    public sealed override Entitas.Systems Add(ISystem system)
    {
        return base.Add(system);
    }
}