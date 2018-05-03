using System;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;
using Event = Spine.Event;

namespace Sources.GamePlay.Player.Scripts
{      
    public class BaseCharacterControler : MonoBehaviour
    {
        public const string ANIMATION_EVENT_1 = "1";
        public const string ANIMATION_EVENT_2 = "2";
        public const string ANIMATION_EVENT_3 = "3";
        public const string ANIMATION_EVENT_4 = "4";
        public const string ANIMATION_EVENT_5 = "5";
        public const string ANIMATION_EVENT_6 = "6";
        
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private Rigidbody rigidbody;

        private bool isCancelable = false;
        private bool isPlayingAnimation = false;

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
                var trackEntry = animationState.SetAnimation(0, animationName, isLoop);
                if (!isLoop)
                {
                    trackEntry.Event += TrackEntryOnEvent;
                }

                return trackEntry;
            }
            return null;
        }

        private void TrackEntryOnEvent(AnimationState state, int trackindex, Event e)
        {
            print("trackindex : " + trackindex);
            print("event : " + e.Data.Name);
            switch (e.Data.name)
            {
                case ANIMATION_EVENT_1:
                    
                    break;
                case ANIMATION_EVENT_2:
     
                    break;
            }
        }
    }
}