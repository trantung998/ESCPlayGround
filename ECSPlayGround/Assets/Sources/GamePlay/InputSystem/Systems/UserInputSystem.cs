using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class UserInputSystem : IExecuteSystem
{
	private InputContext inputContext;

	private string playerId = "PLayer1";
	private bool flag = false;
	public UserInputSystem(Contexts contexts)
	{
		inputContext = contexts.input;
	}

	public void Execute()
	{
		var isFire = Input.GetKeyDown("mouse 0");
		if (isFire)
		{
			var atkInputEntity = inputContext.CreateEntity();
		    atkInputEntity.AddAtkInput(playerId, AtkId.Normal);
			atkInputEntity.isCharacterInput = true;
		}
		
		var moveInput = Input.GetAxis(InputParam.Horizontal);
		if (moveInput <= -0.1f  || moveInput >= 0.1f)
		{		
			var moveInputEntity = inputContext.CreateEntity();
//			Debug.Log("Horizontal value : " + moveInput);
			moveInputEntity.AddMoveInput(
				playerId,
				moveInput,
				moveInput > 0 ? MoveDirection.Right : MoveDirection.Left,
				Time.deltaTime);
			flag = false;
		}
		else if(flag == false && moveInput == 0)
		{	
			var moveInputEntity = inputContext.CreateEntity();
			moveInputEntity.AddMoveInput(playerId, moveInput, MoveDirection.None, 0);
			flag = true;
		}
	}
}
