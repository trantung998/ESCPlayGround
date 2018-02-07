using Entitas;
using Entitas.Unity;
using GamePlay.GameEvents;
using Sources.GamePlay.Player.MonoScripts;
using UniRx;
using UnityEngine;

namespace Sources.GamePlay.Player.System
{
    public class InitPlayerSystem : IInitializeSystem
    {
        private GameContext gameContext;

        public InitPlayerSystem(Contexts contexts)
        {
            gameContext = contexts.game;
        }
        
        public void Initialize()
        {
            var playerPrefab = gameContext.gameplayData.value.heroPrefab;
            var playerObject = GameObject.Instantiate(playerPrefab);
            
            var player = gameContext.CreateEntity();
            player.AddPlayerId("Player1");
            player.AddSpeed(100,100);
            player.AddCharacterControl(playerObject.GetComponent<BaseCharacterControler>());
            playerObject.Link(player, gameContext);
            
            MessageBroker.Default.Publish(new SetPlayerIdEvent("Player1"));
        }
    }
}