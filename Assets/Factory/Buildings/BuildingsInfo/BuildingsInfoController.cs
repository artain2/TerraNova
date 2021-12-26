using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerraNova.Factory
{
    public class BuildingsInfoController : MonoBehaviour
    {
        [SerializeField] BuildingConfig[] configs;

        public BuildingConfig[] Configs => configs;
    }
}