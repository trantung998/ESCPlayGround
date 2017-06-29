using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

using Entitas.Blueprints;

[Game]
public class ViewComponent : IComponent
{
    public GameObject gameObject;
}

[Game]
public sealed class AssetComponent : IComponent
{

    public string name;
}


