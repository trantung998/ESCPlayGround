using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InputExeSystem : IExecuteSystem
{
    private readonly InputContext inputContext;
    private readonly IInputService _inputService;
    private readonly ICameraService _cameraService;

    public InputExeSystem(Contexts contexts)
    {
        this.inputContext = contexts.input;
        this._inputService = contexts.meta.inputService.instance;
        _cameraService = contexts.meta.cameraService.instance;
    }

    public void Execute()
    {
        if (_inputService.IsTouch)
        {
            var inputEntity = inputContext.CreateEntity();
            var screenPosition = _cameraService.ScreenToWorldPoint(_inputService.TouchPosition);
            inputEntity.AddPlayerInput(true, screenPosition);
        }
    }
}