using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.CodeGenerator.Api;

namespace Assets.Scripts.Components.GameSate
{
    [GameState, Unique]
    public class GameScoreComponent : IComponent
    {
        public int value;
    }
}
