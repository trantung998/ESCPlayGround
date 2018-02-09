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

        private void Awake()
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

        public void PlayAnimation(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.None:
                    break;
                case PlayerState.Idle:
                    SetAnimation(GamePlayStatic.ANIMATION_IDLE);
                    break;
                case PlayerState.Move:
                    SetAnimation(GamePlayStatic.ANIMATION_WALK);
                    break;
                case PlayerState.Jump:
                    break;
                case PlayerState.Atk:
                    SetAnimation(GamePlayStatic.ANIMATION_ATK);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }
        }
        
        public virtual TrackEntry SetAnimation(string animationName, bool isLoop = false)
        {  
            return animationState.SetAnimation(0, animationName, isLoop);
        }
    }
}