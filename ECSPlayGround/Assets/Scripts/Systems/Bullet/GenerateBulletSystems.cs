using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Systems.Bullet
{
    public class GenerateBulletSystems : ReactiveSystem<InputEntity>
    {
        private InputContext inputContext;
        private IGroup<GameEntity> player;
        private GameContext gameContext;
        protected override void Execute(List<InputEntity> entities)
        {
            var playerEntity = gameContext.GetEntitiesWithPlayerId(entities[0].playerAttackInput.playerId).ToArray()[0];
            var playerPos = playerEntity.view.value.transform.localPosition;
            
            var bullet = gameContext.CreateEntity();
            bullet.isBullet = true;
            bullet.isDestroyed = false;
            bullet.isOnDestroyEffect = true;
            bullet.AddDamage(10);
            bullet.AddPosition(playerPos);
            bullet.AddVelocity(Vector3.forward);
            
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasPlayerAttackInput;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.PlayerAttackInput);
        }

        public GenerateBulletSystems(Contexts contexts) : base(contexts.input)
        {
            inputContext = contexts.input;
            gameContext = contexts.game;
            player = contexts.game.GetGroup(GameMatcher.PlayerId);
        }
    }
}
