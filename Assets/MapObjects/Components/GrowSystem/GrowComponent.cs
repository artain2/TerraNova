using Sirenix.Serialization;

namespace MapObjects.Components
{
    public class GrowComponent : IComponent
    {
        public class GrowConfig : IComponentConfig
        {
            public IComponentData DefaultData { get; } = new GrowData();
        }

        [System.Serializable]
        public class GrowData : IComponentData
        {
            public float CurrentGrowProgress;
            public float CurrentGrowSpeed;
        }
        
        public TickType TickType { get; }
        public void Tick(float delta)
        {
            
        }

        public string Key { get; }
        public IComponentConfig Config { get; }
        public IComponentData Data { get; }
    }
}