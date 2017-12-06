using System;
using System.Collections.Generic;
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
            var bullet = gameContext.CreateEntity();
            bullet.isBullet = true;
            bullet.AddDamage(10);
            bullet.AddPosition(Vector3.zero);
            bullet.AddVelocity(Vector3.forward);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.isPlayerAttackInput;
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
