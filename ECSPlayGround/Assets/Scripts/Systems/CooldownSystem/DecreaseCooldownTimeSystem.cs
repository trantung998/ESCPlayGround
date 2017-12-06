using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Systems.CooldownSystem
{
    public class DecreaseCooldownTimeSystem : IExecuteSystem, ICleanupSystem
    {
        private InputContext context;

        private IGroup<InputEntity> cooldownEntities;
        private IGroup<InputEntity> cleanupCooldownEnetities; 
        public DecreaseCooldownTimeSystem(Contexts contexts)
        {
            this.context = contexts.input;
            cooldownEntities = context.GetGroup(InputMatcher.Coolddown);
            cleanupCooldownEnetities =
                context.GetGroup(InputMatcher.AllOf(InputMatcher.Coolddown, InputMatcher.Destroyed));
        }

        public void Execute()
        {
            foreach (var entity in cooldownEntities.GetEntities())
            {
                var cooldownComponent = entity.coolddown;
                var cooldown = cooldownComponent.value;

                cooldown -= Time.deltaTime;
                entity.ReplaceCoolddown(cooldownComponent.id, cooldown);
                if (cooldown <= 0)
                {
                    entity.isDestroyed = true;
                    Debug.Log("entity cooldown pass: " + cooldownComponent.id); 
                }
            }
        }

        public void Cleanup()
        {
            foreach (var enetity in cleanupCooldownEnetities.GetEntities())
            {
                enetity.Destroy();
            }
        }
    }
}
