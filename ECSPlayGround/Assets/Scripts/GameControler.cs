using System.Collections;
using System.Collections.Generic;
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

    private Systems CreateSystem(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new InputSystem(contexts));
    }
}
