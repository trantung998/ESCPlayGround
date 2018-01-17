using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class UserInputSystem : IExecuteSystem
{
	private InputContext inputContext;

	public UserInputSystem(Contexts contexts)
	{
		inputContext = contexts.input;
	}

	public void Execute()
	{
		var moveInput = Input.GetAxis(InputParam.Horizontal);
	}
}
