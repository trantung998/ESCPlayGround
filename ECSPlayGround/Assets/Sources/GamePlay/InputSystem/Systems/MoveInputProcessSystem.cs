﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using GamePlay.GameEvents;
using UniRx;

namespace Sources.GamePlay.InputSystem.Systems
{
    public class MoveInputProcessSystem : 
        ReactiveSystem<InputEntity>,
        IInitializeSystem,
        ICleanupSystem, 
        ITearDownSystem
    {
        private IGroup<InputEntity> moveInputs;
        private GameContext gameContext;
        private CompositeDisposable disposable;
        private string currentPlayerId;
        
        public MoveInputProcessSystem(Contexts contexts) : base(contexts.input)
        {
            gameContext = contexts.game;
            moveInputs = contexts.input.GetGroup(InputMatcher.MoveInput);
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
            var currentPlayerEntity = gameContext.GetEntitiesWithPlayerId(currentPlayerId).ToArray()[0];
        }

        public void Cleanup()
        {
            foreach (var inputEntity in moveInputs)
            {
                inputEntity.Destroy();
            }
        }

        public void TearDown()
        {
            disposable.Clear();
        }

        public void Initialize()
        {
            disposable = new CompositeDisposable();
            MessageBroker.Default.Receive<SetPlayerIdEvent>()
                .Subscribe(@event => currentPlayerId = @event.playerId)
                .AddTo(disposable);
        }
    }
}