using System;
using UnityEngine;

[Serializable]
public class BoundData
{
    public Vector3 position;
    public Vector3 scale;
}
[Serializable]
public class MoveBound
{
    public float top;
    public float bottom;
    public float left;
    public float right;
}

[CreateAssetMenu]
public class MapConfigs : ScriptableObject
{
    public GameObject boundPrefab;
    
    public BoundData topBoundData;
    public BoundData bottomBoundData;

    [Space(10)] 
    public MoveBound moveBound;
}
