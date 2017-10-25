using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game, Input]
public class PlayerIdComponent : IComponent
{
    [EntityIndex]
    public string value;
}

