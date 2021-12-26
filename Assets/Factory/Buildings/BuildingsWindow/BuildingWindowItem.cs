using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace TerraNova.Factory
{
    public class BuildingWindowItem : MonoBehaviour
    {

        [SerializeField] Image _icon;
        [SerializeField] Text _name;
        [SerializeField] Button _btn;

        Action<BuildingWindowItem> _clickCallback;

        public BuildingConfig ConfigHandle { get; private set; }

        private void Start()
        {
            _btn.onClick.AddListener(() => _clickCallback(this));
        }

        public BuildingWindowItem SetClickCallback(Action<BuildingWindowItem> clickCallback)
        {
            _clickCallback = clickCallback;
            return this;
        }

        public BuildingWindowItem SetName(string value)
        {
            _name.text = value;
            return this;
        }
        public BuildingWindowItem SetIcon(Sprite value)
        {
            _icon.sprite = value;
            return this;
        }
        public BuildingWindowItem SetHandle(BuildingConfig config)
        {
            ConfigHandle = config;
            return this;
        }
    }
}