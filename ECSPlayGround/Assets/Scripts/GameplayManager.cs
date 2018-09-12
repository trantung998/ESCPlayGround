using System.Collections;
using System.Collections.Generic;
using Systems.Game.Systems;
using Entitas;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private Entitas.Systems systems;

    private Services services;

    private bool IsInit = false;

    // Use this for initialization
    void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        services = new Services(
            new MouseInputService(),
            new UnityViewService(),
            new LGPoolService(),
            GetComponent<UnityGameplayConfigurationService>(),
            new UnityCameraService());

        var regService = new ServiceRegistrationSystems(contexts, services);
        regService.Initialize();

        systems = CreateSystems(contexts);
        systems.Initialize();
        IsInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInit) return;

        systems.Execute();
        systems.Cleanup();
    }

    void OnDestroy()
    {
        systems.TearDown();
    }

    private Entitas.Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
                .Add(new InputExeSystem(contexts))
                //events
                .Add(new GameEventSystems(contexts))
                //Add View System
                .Add(new AssetReactiveSystem(contexts))

                //Player input
                .Add(new PlayerInputProcessSystem(contexts))
                .Add(new PlayerMoveComandSystem(contexts))
                .Add(new PlayerInputDestroySystem(contexts))
                //Init
                .Add(new GameplayInitSystem(contexts))
            ;
    }
}