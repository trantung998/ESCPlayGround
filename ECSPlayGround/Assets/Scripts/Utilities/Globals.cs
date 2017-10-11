using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    public GameObject HexagonGameObject;

    public float widthSpacing = 3.85f;
    public float heightSpacing = 4.45f;
    public float heightOffset = -2.23f;

    public Color oddColor;

}

