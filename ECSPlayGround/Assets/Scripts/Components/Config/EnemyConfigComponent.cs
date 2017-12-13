using DataStructs;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class EnemyConfigComponent : IComponent
{
    public EnemyData value;
}