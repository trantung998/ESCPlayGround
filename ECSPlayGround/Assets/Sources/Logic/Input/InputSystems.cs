using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Logic.Input
{
    public sealed class InputSystems : Feature
    {
        public InputSystems(Contexts contexts) : base("Input Systems")
        {
            Add(new EmitInputSystem(contexts));
            Add(new ProcessInputSystem(contexts));
        }
    }
}
