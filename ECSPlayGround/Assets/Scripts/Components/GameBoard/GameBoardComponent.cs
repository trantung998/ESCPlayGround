using Entitas;
using Entitas.CodeGenerator.Api;

namespace Components.GameBoard
{
    [Game, Unique]
    public sealed class GameBoardComponent: IComponent
    {
        public int colums;
        public int row;
    }
}
