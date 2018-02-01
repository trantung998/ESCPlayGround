using Entitas;

[Input]
public class MoveInputComponent : IComponent
{
    public string Id;
    public float value;
    public MoveDirection Direction;
}
