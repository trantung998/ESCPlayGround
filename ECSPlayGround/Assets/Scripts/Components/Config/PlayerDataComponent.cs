using DataStructs;
using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game, Unique]
public class PlayerDataComponent : IComponent
{
    public PlayerDataModel value;
}

