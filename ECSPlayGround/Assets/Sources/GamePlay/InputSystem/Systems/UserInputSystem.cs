using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class UserInputSystem : IExecuteSystem
{
	private InputContext inputContext;

	private string playerId = "PLayer1";
	public UserInputSystem(Contexts contexts)
	{
		inputContext = contexts.input;
	}

	public void Execute()
	{
		var moveInput = Input.GetAxis(InputParam.Horizontal);
		var moveInputEntity = inputContext.CreateEntity();
		if (moveInput != 0.0f)
		{
//			Debug.Log("Horizontal value : " + moveInput);
			moveInputEntity.AddMoveInput(
				playerId,
				moveInput,
				moveInput > 0 ? MoveDirection.Right : MoveDirection.Left,
				Time.deltaTime);
		}
		else
		{
			moveInputEntity.AddMoveInput(playerId, moveInput, MoveDirection.None, 0);
		}
	}
}
