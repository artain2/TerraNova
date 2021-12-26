namespace MapObjects
{
    public enum TickType
    {
        None,
        Update,
        FixedUpdate,
        LateUpdate,
        Coroutine
    }
    
    public interface ITickable
    {
        TickType TickType { get; }
        void Tick(float delta);
        
    }
}