using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.CodeGenerator.Api;
using SourceMatchOne;

namespace Assets.Scripts.Components.GameBoard
{
    [Game]
    public class PositionComponent : IComponent
    {
        [EntityIndex]
        public IntVector2 value;
    }
}
