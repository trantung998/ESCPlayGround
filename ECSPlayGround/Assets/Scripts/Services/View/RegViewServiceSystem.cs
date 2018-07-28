using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;


internal class RegViewServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IViewService _service;

    public void Initialize()
    {
        _metaContext.ReplaceViewService(_service);
    }

    public RegViewServiceSystem(MetaContext metaContext, IViewService inputService)
    {
        _metaContext = metaContext;
        _service = inputService;
    }
}