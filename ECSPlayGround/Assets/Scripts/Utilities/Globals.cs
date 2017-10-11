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
}

