using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta, Unique]
public class PoolServiceComponent : IComponent
{
    public IPoolService instance;
}