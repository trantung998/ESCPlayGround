using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.GamePlay.Player.Data;

[Game, Unique]
public class GameplayDataComponent : IComponent
{
    public GameplayData value;
}
