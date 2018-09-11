using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Events
{
    [Game, Event(EventTarget.Self)]
    public class PositionComponent : IComponent
    {
        public Vector2D value;
    }

//    [Game, Event(EventTarget.Self)]
//    public class ViewComponent : IComponent
//    {
//        public string assetPath;
//    }
}