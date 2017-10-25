
    using Entitas;
    using Entitas.CodeGeneration.Attributes;
    using UnityEngine;

[Input]
public class MoveInputComponent : IComponent
{
    [EntityIndex]
    public string id;

    public Vector3 value;
}