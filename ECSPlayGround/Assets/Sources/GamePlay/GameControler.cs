using GamePlay.GameEvents;
using UniRx;
using UnityEngine;

namespace Sources.GamePlay
{
    public class GameControler : MonoBehaviour
    {
        private Entitas.Systems systems;

        private void Start()
        {
            Contexts contexts = Contexts.sharedInstance;
            systems = CreateSystem(contexts);
            systems.Initialize();
            Init();
        }

        private void Init()
        {
            
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

        private Entitas.Systems CreateSystem(Contexts contexts)
        {
            return new Feature("Systems")
                .Add(new UserInputSystem(contexts));
        }
    }
}