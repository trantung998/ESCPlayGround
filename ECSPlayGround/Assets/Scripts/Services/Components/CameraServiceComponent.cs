using Entitas;
using Entitas.CodeGeneration.Attributes;


[Meta, Unique]
public class CameraServiceComponent : IComponent
{
    public ICameraService instance;
}