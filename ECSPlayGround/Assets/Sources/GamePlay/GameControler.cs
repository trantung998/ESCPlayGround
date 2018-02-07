using GamePlay.GameEvents;
using Sources.GamePlay.InputSystem.Systems;
using Sources.GamePlay.Player.Data;
using Sources.GamePlay.Player.System;
using UniRx;
using UnityEngine;

namespace Sources.GamePlay
{
    public class GameControler : MonoBehaviour
    {
        [SerializeField]
        private GameplayData gameplayData;
        
        private Entitas.Systems systems;
        private void Start()
        {
            Init();
            Contexts contexts = Contexts.sharedInstance;
            contexts.game.gameplayData.value = gameplayData;
            systems = CreateSystem(contexts);
            systems.Initialize();
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
                .Add(new InitPlayerSystem(contexts))
                .Add(new UserInputSystem(contexts))
                .Add(new MoveInputProcessSystem(contexts));
        }
    }
}