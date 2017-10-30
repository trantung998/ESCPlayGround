using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class PlayerInitialSystem : IInitializeSystem
    {
        Contexts contexts;
        public PlayerInitialSystem(Contexts ctx)
        {
            contexts = ctx;
        }

        public void Initialize()
        {
            var player = contexts.game.CreateEntity();
            player.AddPosition(Vector3.zero);
            player.AddVelocity(Vector3.zero);
            player.AddPlayerId("Player1");
            player.isDestroyed = false;

            var playerData = contexts.game.playerData.value;
            if (playerData != null)
            {
                var playerObj = GameObject.Instantiate(playerData.playerModel);
                var transform = playerObj.transform;

                transform.localPosition = Vector3.zero;
                transform.localScale = Vector3.one;

                playerObj.Link(player, contexts.game);
                player.AddView(playerObj);
            }

        }
    }
}
