using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Logic.Input;
using Entitas;
using Entitas.Blueprints.Unity;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameControler : MonoBehaviour
    {
        public Blueprints blueprints;

        Systems systems;

        void Start()
        {
            var contexts = Contexts.sharedInstance;
            contexts.game.SetBlueprints(blueprints);

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
            return new Feature("Systems")
                 //input
                .Add(new InputSystems(contexts))
                
                //init, logic update
                .Add(new GameBoardSystems(contexts))
                .Add(new ScoreFeature(contexts))
                //update render
                .Add(new ViewSystems(contexts))
                //destroy
                .Add(new DestroySystem(contexts));
        }
    }
}
