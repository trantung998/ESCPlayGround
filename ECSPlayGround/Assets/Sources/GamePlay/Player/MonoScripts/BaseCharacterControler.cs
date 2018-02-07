using Spine.Unity;
using UnityEngine;

namespace Sources.GamePlay.Player.MonoScripts
{
    public class BaseCharacterControler : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private Rigidbody rigidbody;

        public Rigidbody Rigidbody
        {
            get { return rigidbody; }
        }

        public SkeletonAnimation SkeletonAnimation
        {
            get { return skeletonAnimation; }
        }
    }
}