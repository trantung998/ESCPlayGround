using UnityEngine;
using Entitas;

public class GameControler : MonoBehaviour
{
    [SerializeField] private Globals globals;
    [SerializeField] private RectTransform UiRoot;

    private Systems system;
	// Use this for initialization
	void Start ()
	{
	    var contexts = Contexts.sharedInstance;

	    contexts.game.SetGlobals(globals);
        contexts.game.SetUiRoot(UiRoot);

	    system = CreateSystems(contexts);
        system.Initialize();
        
	}

    void Update()
    {
        system.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Hello System")
            .Add(new InitializeHecagonSystem(contexts))
            .Add(new AddViewHexagonReactiveSystem(contexts))
            .Add(new ShowHexagontypeSystem(contexts))
            .Add(new CheckClickInputSystem(contexts));
    }
}
