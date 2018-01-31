using Spine.Unity;
using UnityEngine;

namespace Sources.GamePlay.Player.MonoScripts
{
    public class BaseCharacterControler : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnimation;

        public SkeletonAnimation SkeletonAnimation
        {
            get { return skeletonAnimation; }
            set { skeletonAnimation = value; }
        }
    }
}