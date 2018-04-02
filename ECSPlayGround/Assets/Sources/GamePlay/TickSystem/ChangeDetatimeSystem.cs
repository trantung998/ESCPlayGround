using Entitas;
using UnityEngine;

namespace Sources.GamePlay.TickSystem
{
    public class ChangeDetatimeSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;

        public ChangeDetatimeSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Execute()
        {
            _gameContext.ReplaceDeltaTime(Time.deltaTime);
        }
    }
}