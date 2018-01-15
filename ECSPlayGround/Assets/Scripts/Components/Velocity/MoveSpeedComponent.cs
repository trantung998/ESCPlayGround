using Entitas;

[Game]
public class MoveSpeedComponent : IComponent
{
    public float value;
    public float effectiveValue;

    public void ReturnBaseValue()
    {
        effectiveValue = value;
    }
}