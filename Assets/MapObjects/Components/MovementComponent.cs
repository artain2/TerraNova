using UnityEngine;

namespace MapObjects.Components
{
    public class MovementComponent : IComponent
    {
        public class MovementData : IComponentData
        {
            public Vector3 Position;
            public Vector3Int Coordinate;
            public float CurrentSpeed;
            public Vector3 CurrentDirection;
        }
        
        public class MovementConfig : IComponentConfig
        {
            public float MaxSpeed;
            public IComponentData DefaultData { get; }
        }

        public string Key { get; }
        
        public IComponentConfig Config { get; }
        
        public IComponentData Data { get; }

        public TickType TickType => TickType.Update;

        public void Tick(float delta)
        {
            var data = (Data as MovementData);
            if (data.CurrentSpeed > 0f)
                data.Position += data.CurrentDirection * data.CurrentSpeed * delta;
        }
    }
}