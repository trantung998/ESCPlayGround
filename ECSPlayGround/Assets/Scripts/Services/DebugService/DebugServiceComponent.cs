using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta, Unique]
public class DebugServiceComponent : IComponent
{
    public IDebugService instance;
}