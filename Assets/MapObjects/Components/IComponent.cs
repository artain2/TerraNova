
namespace MapObjects.Components
{
    public interface IComponent : ITickable
    {
        string Key { get; }
        IComponentConfig Config { get; }
        IComponentData Data { get; }
        
    }
}