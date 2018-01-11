using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DesperateDevs.Utils;
using Entitas;
using Entitas.Unity;
using UnityCode.Core.Scripts.ObjectPooling;
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
            player.AddArmor(10);
            player.AddHealth(1000);
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

            var enemyConfig = contexts.game.enemyConfig;
            var enemyEntity = contexts.game.CreateEntity();
            enemyEntity.AddPosition(enemyConfig.value.spawnPosition);

            var enemyObj = GameObject.Instantiate(enemyConfig.value.prefab);
            var enemyObjTransform = enemyObj.transform;
            enemyObjTransform.localPosition = Vector3.zero;
            enemyObjTransform.localScale = Vector3.one;
            enemyObj.Link(enemyEntity, contexts.game);
            enemyEntity.AddView(enemyObj);
            enemyEntity.AddArmor(10);
            enemyEntity.AddHealth(1000);
            enemyEntity.isAutoHorizontalMove = true;
            enemyEntity.AddVelocity(new Vector3(0.2f, 0, 0));
            enemyEntity.AddVelocity(new Vector3(0.2f, 0, 0));
            
            InitPools();
        }
        
        private void InitPools()
        {
            var bulletPrefab = contexts.game.playerData.value.bulletMoldel;
            ObjectPool.manageRecycleBin(new ObjectRecycleBin()
            {
                instancesToPreallocate = 5,
                prefab = bulletPrefab
            });
            
            var hitPrefab = contexts.game.playerData.value.hitEffect;
            ObjectPool.manageRecycleBin(new ObjectRecycleBin()
            {
                instancesToPreallocate = 5,
                prefab = hitPrefab,
                automaticallyRecycleParticleSystems = true
            });
        }
    }
}
