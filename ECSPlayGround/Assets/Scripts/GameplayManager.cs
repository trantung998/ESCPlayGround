using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private Systems systems;

    private Services services;

    // Use this for initialization
    void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        services = new Services(
            new MouseInputService(),
            new UnityViewService(),
            new ObjectPool(),
            GetComponent<UnityGameplayConfigurationService>());
        var regService = new ServiceRegistrationSystems(contexts, services);
        regService.Initialize();

        systems = CreateSystems(contexts);
        systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }

    void OnDestroy()
    {
        systems.TearDown();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new InputExeSystem(contexts));
    }
}