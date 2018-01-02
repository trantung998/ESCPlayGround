using Entitas;

public enum DamageType
{
    None,
    Physic,
    Magic,
    Pure,
}

[Game]
public class DamageComponent : IComponent
{
    public int value;
    public DamageType DamageType = DamageType.None;
}
