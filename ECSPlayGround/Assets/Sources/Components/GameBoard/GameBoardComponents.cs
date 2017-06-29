using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique, Game]
public class GameBoardComponent : IComponent
{
    public int rows;
    public int cols;
}

[Game]
public sealed class GameBoardElementComponent : IComponent
{
}

[Game]
public sealed class MovableComponent : IComponent
{
}

[Game]
public sealed class PositionComponent : IComponent
{

    [EntityIndex]
    public IntVector2 value;
}