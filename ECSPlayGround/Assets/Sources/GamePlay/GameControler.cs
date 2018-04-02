using GamePlay.GameEvents;
using Sources.GamePlay.InputSystem.Systems;
using Sources.GamePlay.Player.Data;
using Sources.GamePlay.Player.System;
using Sources.GamePlay.TickSystem;
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
            Application.targetFrameRate = 60;
            
            Contexts contexts = Contexts.sharedInstance;
            contexts.game.SetGameplayData(gameplayData);
            contexts.game.SetDeltaTime(0);
            contexts.game.SetTickTime(0);
            
            systems = CreateSystem(contexts);
            systems.Initialize();
            Init();
        }

        private void Init()
        {
            MessageBroker.Default.Publish(new SetPlayerIdEvent("Player1"));
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

                //inti
                .Add(new InitPlayerSystem(contexts))
                .Add(new UserInputSystem(contexts))
                .Add(new ChangeDetatimeSystem(contexts))
                .Add(new TickTimeIncreasementSystem(contexts))
                .Add(new CooldownControlSystem(contexts))
                .Add(new DestroyInputSystem(contexts))
                .Add(new CharacterMoveInputHandlerSystem(contexts))
                .Add(new PlayerAttkProcessSystem(contexts))
                .Add(new FacingReactiveSystem(contexts))
                .Add(new CharacterAnimationSystem(contexts))
                .Add(new ClearAnimationStateEntitySystem(contexts))
                ;
        }
    }
}