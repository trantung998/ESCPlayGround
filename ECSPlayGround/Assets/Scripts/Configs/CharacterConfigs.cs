using System;
using UnityEngine;

[Serializable]
public class CharacterConfigs
{
    public string characterPrefabPath;
    
    public Vector2 topRight, botLeft;
    
    public float MoveSpeed;
    public float StopMove;

    public Vector3 RespawnPosition;
}