using System;
using System.Collections.Generic;
using MapObjects.Components;
using UnityEngine;

namespace MapObjects
{
    [Serializable]
    public class MapObjectData
    {
        public Guid Guid;
        public Vector2Int Coordinate;
        public Vector3 Position;
        
        public List<IComponentData> Datas;
    }
}