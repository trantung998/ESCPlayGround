using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Systems;
using Entitas;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    private Systems systems;

	// Use this for initialization
	void Start () {
		Contexts contexts = Contexts.sharedInstance;

	    systems = CreateSystem(contexts);

        systems.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		systems.Execute();
        systems.Cleanup();
	}

    void OnDestroy()
    {
        systems.TearDown();
    }

    private Systems CreateSystem(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new InputSystem(contexts))
            .Add(new PlayerInitialSystem(contexts))

            //update
            .Add(new VelocityHandlerSystem(contexts))
            //reactive
            .Add(new PositionHandlerSystem(contexts))
            .Add(new ProcessMoveInputSystems(contexts));
    }
}
