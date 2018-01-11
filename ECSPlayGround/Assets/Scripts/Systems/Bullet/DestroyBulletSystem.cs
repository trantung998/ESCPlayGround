using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Unity;
using UniRx;
using UnityCode.Core.Scripts.ObjectPooling;
using UnityEngine;

namespace Assets.Scripts.Systems.Bullet
{
    public class DestroyBulletSystem : ICleanupSystem, IExecuteSystem
    {
        private IGroup<GameEntity> bulletDestroyed;
        private IGroup<GameEntity> activeBulletGroup;
        private PlayerDataModel playerConfigs;
        
        public DestroyBulletSystem(Contexts contexts)
        {
            playerConfigs = contexts.game.playerData.value;
            bulletDestroyed = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet, GameMatcher.Destroyed));
            
            activeBulletGroup = contexts.game.GetGroup(
                GameMatcher
                    .AllOf(GameMatcher.Bullet, GameMatcher.Lifetime));
        }
        
        public void Cleanup()
        {
            foreach (var entity in bulletDestroyed.GetEntities())
            {
                var view = entity.view.value;
                view.Unlink();
                
                ObjectPool.despawn(view);
                if (entity.isOnDestroyEffect)
                {
                    var position = entity.position.value;
                    var effect = ObjectPool.spawn(playerConfigs.hitEffect);
                    effect.transform.localPosition = position;
                }
                entity.Destroy();
                MessageBroker.Default.Publish(new BulletDestroyEvent());
            }
        }

        public void Execute()
        {
            var entities = activeBulletGroup.GetEntities();
            foreach (var gameEntity in entities)
            {
                var currentLifeTimeValue = gameEntity.lifetime.value;
                currentLifeTimeValue -= Time.deltaTime;
                gameEntity.ReplaceLifetime(currentLifeTimeValue);
                if (currentLifeTimeValue <= 0)
                {
                    gameEntity.isDestroyed = true;
                }
            }
        }
    }
}
