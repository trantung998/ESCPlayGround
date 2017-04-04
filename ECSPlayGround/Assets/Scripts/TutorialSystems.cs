using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Scripts
{
    public class TutorialSystems : Feature
    {
        public TutorialSystems(Contexts contexts) : base("Tutorial Systems")
        {
            Add(new MainSystem(contexts.game));
            Add(new DebugMessageSystem(contexts.game));
        }
    }
}
