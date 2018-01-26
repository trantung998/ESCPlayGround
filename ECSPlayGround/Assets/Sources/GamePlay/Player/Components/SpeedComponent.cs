using Entitas;

[Game]
public class SpeedComponent : IComponent
{
    public float baseValue;
    public float effectiveValue;
    
    public void ReturnBaseValue()
    {
        effectiveValue = baseValue;
    }
}