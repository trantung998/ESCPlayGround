using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public enum CharacterType
{
    Player,
    Enemy,
    MiniBoss,
    SuperBoss,
}

public enum CharacterState
{
    Normal,
    Death,
}

[Game]
public class CharacterIdComponent : IComponent
{
    [EntityIndex] public string value;
}

[Game]
public class CharacterPositionComponent : IComponent
{
    public Vector3 value;
}

[Game]
public class CharacterMoveSpeed : IComponent
{
    public float value;
}

[Game]
public class CharacterTypeComponent : IComponent
{
    [EntityIndex] public CharacterType value;
}

[Game]
public class CharacterStateComponent : IComponent
{
    public CharacterState value;
}