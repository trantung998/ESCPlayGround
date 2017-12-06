using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class AddViewBulletSystem : ReactiveSystem<GameEntity>
    {

        private GameContext gameContext;
        public AddViewBulletSystem(Contexts contexts) : base(contexts.game)
        {
            gameContext = contexts.game;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Bullet);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBullet && entity.hasPosition 
                && !entity.hasView && !entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var bulletPrefab = gameContext.playerData.value.bulletMoldel;
            foreach (var entity in entities)
            {
                var bulletObj = GameObject.Instantiate(bulletPrefab);
                bulletObj.transform.localScale = Vector3.one;
                bulletObj.transform.localPosition = entity.position.value;

                bulletObj.Link(entity, gameContext);

                entity.AddView(bulletObj);

            }
        }
    }
}
