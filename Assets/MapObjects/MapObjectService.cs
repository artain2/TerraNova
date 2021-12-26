using System;
using System.Collections.Generic;
using MapObjects.Services;
using UnityEngine;

namespace MapObjects
{
    public class MapObjectService : IService
    {
       
        public string Key { get; }

        private List<MapObject> _mapObjects;
        
        public TickType TickType => TickType.Update;

        public void Tick(float delta)
        {
            Debug.Log($"{nameof(MapObjectService)} {nameof(Tick)}");
            foreach (var mapObject in _mapObjects)
            {
                mapObject.Tick(delta);
            }
        }
    }
}