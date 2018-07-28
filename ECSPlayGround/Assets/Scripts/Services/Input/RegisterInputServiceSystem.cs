using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;


public class RegisterInputServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IInputService _inputService;
    public void Initialize()
    {
        _metaContext.ReplaceInputService(_inputService);
    }

    public RegisterInputServiceSystem(MetaContext metaContext, IInputService inputService)
    {
        _metaContext = metaContext;
        _inputService = inputService;
    }
}

