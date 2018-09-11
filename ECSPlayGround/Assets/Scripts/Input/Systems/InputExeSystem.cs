using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InputExeSystem : IExecuteSystem
{
    private readonly InputContext inputContext;
    private readonly IInputService _inputService;

    public InputExeSystem(Contexts contexts)
    {
        this.inputContext = contexts.input;
        this._inputService = contexts.meta.inputService.instance;
    }

    public void Execute()
    {
        if (_inputService.IsTouch)
        {
            var inputEntity = inputContext.CreateEntity();
            inputEntity.AddPlayerInput(true, _inputService.TouchPosition);
        }
    }
}