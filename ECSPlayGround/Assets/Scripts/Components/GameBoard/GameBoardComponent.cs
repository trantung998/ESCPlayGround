using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.CodeGenerator.Api;

namespace Assets.Scripts.Components
{
    [Game, Unique]
    public sealed class GameBoardComponent: IComponent
    {
        public int colums;
        public int row;
    }
}
