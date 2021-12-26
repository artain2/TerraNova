using System;
using System.Collections.Generic;
using UnityEngine;

using MapObjects.Components;

namespace MapObjects
{
    public class MapObject : MonoBehaviour, ITickable
    {
        private MapObjectConfig _config;
        private MapObjectData _data;

        private List<IComponent> _components;
        
        public TickType TickType => TickType.Update;

        private void Start()
        {
            _components = new List<IComponent>();
            
        }

        public void Tick(float delta)
        {
            Debug.Log($"Nothing happened ¯\\_(ツ)_/¯ delta={delta}");
        }
    }
}