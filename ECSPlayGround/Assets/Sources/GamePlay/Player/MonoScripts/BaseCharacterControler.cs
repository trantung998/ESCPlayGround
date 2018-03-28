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

        public void PlayAnimation(CharacterFiniteState animationState)
        {
            switch (animationState)
            {
                case CharacterFiniteState.None:
                    break;
                case CharacterFiniteState.Idle:
                    SetAnimation(GamePlayStatic.ANIMATION_IDLE, true);
                    break;
                case CharacterFiniteState.Move:
                    SetAnimation(GamePlayStatic.ANIMATION_WALK, true);
                    break;
                case CharacterFiniteState.Jump:
                    break;
                case CharacterFiniteState.Atk:
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