using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Logic.Input;
using Entitas;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameControler : MonoBehaviour
    {
        Systems systems;

        void Start()
        {
            var contexts = Contexts.sharedInstance;

            systems = createSystems(contexts);
            systems.Initialize();
        }

        void Update()
        {
            systems.Execute();
            systems.Cleanup();
        }

        void OnDestroy()
        {
            systems.TearDown();
        }

        Systems createSystems(Contexts contexts)
        {
            return new Feature("Systems").Add(new InputSystems(contexts));
        }
    }
}
