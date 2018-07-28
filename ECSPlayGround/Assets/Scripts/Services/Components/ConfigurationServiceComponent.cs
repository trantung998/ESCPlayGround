using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta, Unique]
public class ConfigurationServiceComponent : IComponent
{
    public IConfigurationService instance;
}