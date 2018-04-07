using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class UserInputSystem : IExecuteSystem
{
	private InputContext inputContext;

	private string playerId = "Player1";
	private bool flag = false;
	public UserInputSystem(Contexts contexts)
	{
		inputContext = contexts.input;
	}

	public void Execute()
	{
	    if (Input.GetKeyDown(KeyCode.A))
	    {
	        OnPointerDownLeft();
	    }
	    else if (Input.GetKeyUp(KeyCode.A))
	    {
	        OnPointerUpLeft();
	    }
	    else if (Input.GetKeyDown(KeyCode.D))
	    {
	        OnPointerDownRight();
	    }
	    else if (Input.GetKeyUp(KeyCode.D))
	    {
	        OnPointerUpRight();
	    }


        var isFire = Input.GetKeyDown("mouse 0");
		if (isFire)
		{
			var atkInputEntity = inputContext.CreateEntity();
		    atkInputEntity.AddAtkInput(playerId, AtkId.Normal);
			atkInputEntity.isCharacterInput = true;
		}
		
		var moveInput = Input.GetAxis(InputParam.Horizontal);
		if (moveInput != 0)
		{		
			var moveInputEntity = inputContext.CreateEntity();
//			Debug.Log("Horizontal value : " + moveInput);
			moveInputEntity.AddMoveInput(
				playerId,
				moveInput,
				moveInput > 0 ? MoveDirection.Right : MoveDirection.Left,
				Time.deltaTime);
			moveInputEntity.isCharacterInput = true;
//			flag = false;
		}
		else if(moveInput == 0)
		{	
			var moveInputEntity = inputContext.CreateEntity();
			moveInputEntity.AddMoveInput(playerId, moveInput, MoveDirection.None, 0);
//			flag = true;
		}
	}
}
