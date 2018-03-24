using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using GamePlay.GameEvents;
using UniRx;
using UnityEngine;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class CharacterMoveInputHandlerSystem : 
        ReactiveSystem<InputEntity>,
        IInitializeSystem,
        ICleanupSystem, 
        ITearDownSystem
    {
        private GameContext gameContext;
        private CompositeDisposable disposable;
        private string currentPlayerId;
        private readonly IGroup<GameEntity> characterEntities;
        
        private GameEntity currentPlayerEntity;
        public CharacterMoveInputHandlerSystem(Contexts contexts) : base(contexts.input)
        {
            gameContext = contexts.game;
            characterEntities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.CharacterFiniteState,
                GameMatcher.CharacterControl, 
                GameMatcher.CharacterState));
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
            foreach (var inputEntity in entities)
            {
                var playerId = inputEntity.moveInput.Id;
                if (currentPlayerEntity.playerId.value != playerId)
                {
                    var characterEntity = characterEntities.GetEntities().First(gameEntity => gameEntity.playerId.value == playerId);
                    if (characterEntity != null)
                    {
                        ProcessMoveInput(characterEntity, inputEntity);
                    }
                }
                else
                {
                    ProcessMoveInput(currentPlayerEntity, inputEntity);
                }
            }
        }
        
        private void ProcessMoveInput(GameEntity playerEntity, InputEntity inputEntity)
        {
            if (playerEntity.hasCharacterControl 
                && playerEntity.hasCharacterFiniteState
                && playerEntity.hasCharacterState)
            {
                if(!playerEntity.isMoveable) return;
                var playerId = playerEntity.playerId.value;
                
                if (inputEntity.moveInput.Direction == MoveDirection.None)
                {
                    if (playerEntity.characterFiniteState.State != CharacterFiniteState.Idle)
                    {
                        playerEntity.ReplaceCharacterFiniteState(CharacterFiniteState.Idle);
                        
                        EmmitChangeAnimationEntity(CharacterFiniteState.Idle, playerId);
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
                if (playerEntity.characterFiniteState.State != CharacterFiniteState.Move)
                {
                    playerEntity.ReplaceCharacterFiniteState(CharacterFiniteState.Move);
                    EmmitChangeAnimationEntity(CharacterFiniteState.Move, playerId);
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
        }

        private void EmmitChangeAnimationEntity(CharacterFiniteState state, string playerId)
        {
            if (currentPlayerEntity != null && currentPlayerEntity.hasPlayerId)
            {
                var changeAnimationEntity = gameContext.CreateEntity();
                changeAnimationEntity.isAnimationControl = true;
                changeAnimationEntity.AddPlayerId(playerId);
                changeAnimationEntity.AddCharacterFiniteState(state);
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
                    currentPlayerEntity = gameContext.GetEntitiesWithPlayerId(currentPlayerId).ToArray()[0];
                })
                .AddTo(disposable);
        }
    }
}