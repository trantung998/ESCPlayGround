using UnityEngine;
using Entitas;

public class GameControler : MonoBehaviour
{
    private Systems system;
	// Use this for initialization
	void Start ()
	{

	    system = CreateSystems(Contexts.sharedInstance);
        system.Initialize();
	}

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Hello System").Add(new InitializeHecagonSystem(contexts));
    }
}
