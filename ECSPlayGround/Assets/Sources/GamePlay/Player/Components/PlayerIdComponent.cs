using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PlayerIdComponent : IComponent
{
    [EntityIndex]
    public string value;
}
