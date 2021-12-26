using UnityEngine;

namespace MapObjects
{
    public class ScriptableObjectContainer<T> : ScriptableObject
    {
        public T Data;
    }
}