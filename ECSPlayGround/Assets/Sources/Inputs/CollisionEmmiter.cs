using Entitas.Unity;
using UnityEngine;

namespace Assets.Sources.Inputs
{
    public class CollisionEmmiter : MonoBehaviour
    {
        public string targetTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wall")
            {
                var bulletLink = gameObject.GetEntityLink();
            }
        }
    }
}
