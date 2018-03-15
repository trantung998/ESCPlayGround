using System;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;

namespace Sources.GamePlay.Player.MonoScripts
{      
    public class BaseCharacterControler : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private Rigidbody rigidbody;

        private AnimationState animationState;

        private void Start()
        {
            animationState = skeletonAnimation.AnimationState;
        }

        public Rigidbody Rigidbody
        {
            get { return rigidbody; }
        }

        public SkeletonAnimation SkeletonAnimation
        {
            get { return skeletonAnimation; }
        }

        public void PlayAnimation(PlayerAnimationState animationState)
        {
            switch (animationState)
            {
                case PlayerAnimationState.None:
                    break;
                case PlayerAnimationState.Idle:
                    SetAnimation(GamePlayStatic.ANIMATION_IDLE, true);
                    break;
                case PlayerAnimationState.Move:
                    SetAnimation(GamePlayStatic.ANIMATION_WALK, true);
                    break;
                case PlayerAnimationState.Jump:
                    break;
                case PlayerAnimationState.Atk:
                    SetAnimation(GamePlayStatic.ANIMATION_ATK);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("animationState", animationState, null);
            }
        }
        
        public TrackEntry SetAnimation(string animationName, bool isLoop = false)
        {
            if (animationState != null)
            {
                return animationState.SetAnimation(0, animationName, isLoop);
            }
            return null;
        }
    }
}