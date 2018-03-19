using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using GamePlay.GameEvents;
using UniRx;
using UnityEngine;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class CharacterInputProcessSystem : 
        ReactiveSystem<InputEntity>,
        IInitializeSystem,
        ICleanupSystem, 
        ITearDownSystem
    {
        private GameContext gameContext;
        private CompositeDisposable disposable;
        private string currentPlayerId;

        private GameEntity playerEntity;
        public CharacterInputProcessSystem(Contexts contexts) : base(contexts.input)
        {
            gameContext = contexts.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.MoveInput);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasMoveInput;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            if (playerEntity.hasCharacterControl)
            {
                if(!playerEntity.isMoveable) return;
                
                var inputEntity = entities[0];
                if (inputEntity.moveInput.Direction == MoveDirection.None)
                {
                    if (playerEntity.characterState.value != PlayerAnimationState.Idle)
                    {
                        playerEntity.ReplaceCharacterState(PlayerAnimationState.Idle);
                        EmmitChangeAnimationEntity(PlayerAnimationState.Idle);
                        Debug.Log("Change State to" + PlayerAnimationState.Idle );
                    }
                    inputEntity.isInputDestroy = true;
                    return;
                }
                
                var moveValue = inputEntity.moveInput.value;
                
                var facingComponent = playerEntity.facingDirection;
                //facing
                if (inputEntity.moveInput.Direction == MoveDirection.Right)
                {
                    if (facingComponent.value == FacingDirection.Left)
                    {
                        facingComponent.value = FacingDirection.Right;
                    }
                }
                else if(inputEntity.moveInput.Direction == MoveDirection.Left)
                {
                    moveValue *= -1;
                    if (playerEntity.facingDirection.value == FacingDirection.Right)
                    {
                        facingComponent.value = FacingDirection.Left;
                    }
                }
                //todo: Add logic check can move
                if (playerEntity.characterState.value != PlayerAnimationState.Move)
                {
                    playerEntity.ReplaceCharacterState(PlayerAnimationState.Move);
                    EmmitChangeAnimationEntity(PlayerAnimationState.Move);
                    Debug.Log("Change State to" + PlayerAnimationState.Move);
                }
     
                //flip
                playerEntity.ReplaceFacingDirection(facingComponent.id, facingComponent.value);
                
                var rigibody = playerEntity.characterControl.value.Rigidbody;

                var newPosition = 
                    rigibody.position +
                    
                    rigibody.transform.right * 
                    inputEntity.moveInput.deltaTime *
                    moveValue * 
                    playerEntity.speed.effectiveValue;

                rigibody.MovePosition(newPosition);
                
                inputEntity.isInputDestroy = true;
            }
//            foreach (var entity in entities)
//            {
//                var playerId = entity.moveInput.Id;
//                var hashSet = gameContext.GetEntitiesWithPlayerId(playerId);
//                if (hashSet != null && hashSet.Any())
//                {
//                    var currentPlayerEntity = hashSet.ToArray()[0];
//                    if (currentPlayerEntity.hasCharacterControl)
//                    {
////                    var inputEntity = entities[0];
//                        //facing right
//                        if (entity.moveInput.Direction == MoveDirection.Right)
//                        {
//                            if (currentPlayerEntity.facingDirection.value == FacingDirection.Left)
//                            {
//                                //flip
//                                currentPlayerEntity.facingDirection.value = FacingDirection.Right;
//                            }
//                        }
//                        else if(entity.moveInput.Direction == MoveDirection.Left)
//                        {
//                            if (currentPlayerEntity.facingDirection.value == FacingDirection.Right)
//                            {
//                                //flip
//                                currentPlayerEntity.facingDirection.value = FacingDirection.Left;
//                            }
//                        }
//
//                        var rigibody = currentPlayerEntity.characterControl.value.Rigidbody;
//
//                        var newPosition = 
//                            rigibody.position +
//                    
//                            rigibody.transform.right * 
//                            entity.moveInput.deltaTime *
//                            entity.moveInput.value * 
//                            currentPlayerEntity.speed.effectiveValue;
//
//                        rigibody.MovePosition(newPosition);
//                    }
//                }  
//                entity.isInputDestroy = true;
//            }
        }

        private void EmmitChangeAnimationEntity(PlayerAnimationState state)
        {
            if (playerEntity != null && playerEntity.hasPlayerId)
            {
                var changeAnimationEntity = gameContext.CreateEntity();
                changeAnimationEntity.isAnimationControl = true;
                changeAnimationEntity.AddPlayerId(playerEntity.playerId.value);
                changeAnimationEntity.AddCharacterState(state);
            }
        }

        public void Cleanup()
        {
        }

        public void TearDown()
        {
            disposable.Clear();
        }

        public void Initialize()
        {
            disposable = new CompositeDisposable();
            MessageBroker.Default.Receive<SetPlayerIdEvent>()
                .Subscribe(@event =>
                {
                    currentPlayerId = @event.playerId;
                    playerEntity = gameContext.GetEntitiesWithPlayerId(currentPlayerId).ToArray()[0];
                })
                .AddTo(disposable);
        }
    }
}