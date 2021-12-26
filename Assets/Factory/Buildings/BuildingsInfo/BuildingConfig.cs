using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerraNova.Factory
{

    [CreateAssetMenu(fileName = "BuildingConfig", menuName = "Config/Building/BuildingConfig")]
    public class BuildingConfig : ScriptableObject
    {
        public int id;
        public Vector2Int _size;
        public Sprite _buildingImage;
        public string _buildingName;
    }
}