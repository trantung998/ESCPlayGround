using Entitas;
using Entitas.CodeGenerator.Api;
using SourceMatchOne;

namespace Components.GameBoard
{
    [Game]
    public class PositionComponent : IComponent
    {
        [EntityIndex]
        public IntVector2 value;
    }
}
