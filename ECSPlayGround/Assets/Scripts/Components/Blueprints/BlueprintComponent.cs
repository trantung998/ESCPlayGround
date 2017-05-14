using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using Entitas.CodeGenerator.Api;

namespace Assets.Scripts.Components.Blueprints
{
    [Game, Unique]
    public class BlueprintComponent : IComponent
    {
        public Entitas.Unity.Blueprints.Blueprints blueprint;
    }
}
