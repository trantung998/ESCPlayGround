using Entitas;
using Entitas.Unity;
using UniRx;
using UnityEngine;

namespace Assets.Sources.Inputs
{
    public class CollisionEmmiter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy" || other.tag == "Bound")
            {
                MessageBroker.Default.Publish(new HitEvent());
                var bulletEntityLink = GetComponent<EntityLink>();
                var gameContext = bulletEntityLink.context as GameContext;
                
                var otherEntityLink = other.gameObject.GetComponent<EntityLink>();
                if (otherEntityLink != null)
                {
                    var collision = gameContext.CreateEntity();
                    collision.AddCollision(bulletEntityLink.entity, otherEntityLink.entity);

                }
            }
        }
    }
}