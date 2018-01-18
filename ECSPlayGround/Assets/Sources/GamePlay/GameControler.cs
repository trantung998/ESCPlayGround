using UnityEngine;

namespace Sources.GamePlay
{
    public class GameControler : MonoBehaviour
    {
        private Entitas.Systems systems;
        
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