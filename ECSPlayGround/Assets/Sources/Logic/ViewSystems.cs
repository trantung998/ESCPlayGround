using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Logic
{
    public class ViewSystems :Feature
    {
        public ViewSystems(Contexts contexts) : base("View Systems")
        {
            Add(new AddViewSystem(contexts));
            Add(new RenderSpriteSystem(contexts));
            Add(new RenderDirectionSystem(contexts));
            Add(new RenderPositionSystem(contexts));
        }
    }
}
