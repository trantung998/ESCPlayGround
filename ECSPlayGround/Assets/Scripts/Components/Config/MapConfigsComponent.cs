using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MapConfigsComponent : IComponent
{
    public MapConfigs value;
}
