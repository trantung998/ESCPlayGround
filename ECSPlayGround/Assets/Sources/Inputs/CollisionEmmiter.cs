using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.Sources.Inputs
{
    public class CollisionEmmiter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                var bulletEntityLink = GetComponent<EntityLink>();
                var otherEntityLink = other.gameObject.GetComponent<EntityLink>();
                if (otherEntityLink != null)
                {
                    //if(otherEntityLink.entity.AddComponent())
                    var otherEntity = otherEntityLink.entity as GameEntity;

                    if (otherEntity != null)
                    {
                        if (!otherEntity.hasHit)
                            otherEntity.AddHit(10);
                        else otherEntity.ReplaceHit(120);
                    }
                }
            }
        }
    }
}