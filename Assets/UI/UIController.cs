using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TerraNova.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] Transform _windowsRoot;
        [SerializeField] UIInstance _uiInstancePrefab;

        public UIInstance UI { get; private set; }

        public void Init()
        {
            UI = Instantiate(_uiInstancePrefab, _canvas.transform);
        }

        public T CreateWindow<T>(T window) where T : MonoBehaviour
        {
            var inst = Instantiate(window, _windowsRoot);
            return inst;
        }
    }
}