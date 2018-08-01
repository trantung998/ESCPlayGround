using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
public class PlayerInputComponent : IComponent
{
    public bool IsTouch;
    public Vector3 TouchPosition;
}

[Input]
public class DestroyPlayerInputComponent : IComponent
{
}

[Input]

public class CharacterMoveCommandComponent : IComponent
{
    public Vector3 Position;
}