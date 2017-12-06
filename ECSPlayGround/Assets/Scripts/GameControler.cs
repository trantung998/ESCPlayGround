using System.Collections;
using System.Collections.Generic;
using Systems.Bullet;
using Assets.Scripts.Systems;
using Systems.CooldownSystem;
using Entitas;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField] private PlayerDataModel playerData;

    private Entitas.Systems systems;

	// Use this for initialization
	void Start () {
		Contexts contexts = Contexts.sharedInstance;
	    contexts.game.ReplacePlayerData(playerData);

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

    private Entitas.Systems CreateSystem(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new InputSystem(contexts))
            .Add(new PlayerInitialSystem(contexts))

            //update
            .Add(new VelocityHandlerSystem(contexts))
            .Add(new DecreaseCooldownTimeSystem(contexts))
            //reactive
            .Add(new GenerateBulletSystems(contexts))
            .Add(new AddViewBulletSystem(contexts))
            .Add(new PositionHandlerSystem(contexts))
            .Add(new ProcessMoveInputSystems(contexts));
    }
}
