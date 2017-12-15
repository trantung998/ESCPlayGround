using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Unity;
using UnityCode.Core.Scripts.ObjectPooling;

namespace Assets.Scripts.Systems.Bullet
{
    public class DestroyBulletSystem : ICleanupSystem
    {
        private IGroup<GameEntity> bulletDestroyed;
        private PlayerDataModel playerConfigs;
        public DestroyBulletSystem(Contexts contexts)
        {
            playerConfigs = contexts.game.playerData.value;
            bulletDestroyed = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Bullet, GameMatcher.Destroyed));
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
            }
        }
    }
}
