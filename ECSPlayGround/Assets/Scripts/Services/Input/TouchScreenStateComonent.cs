using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Event(EventTarget.Self, EventType.Added)]
[Event(EventTarget.Self, EventType.Removed)]
public class TouchScreenStateComonent : IComponent
{
}