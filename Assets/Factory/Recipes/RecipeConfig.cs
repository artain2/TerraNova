using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerraNova.Factory
{
    public class RecipeConfig : ScriptableObject
    {
        public int _recipeId;
        public string _recipeName;
        public Sprite _recipeIcon;
        public float _craftTime;
        public List<BuildingConfig> _craftBuildingsList;
        public List<GameItemAmountNode> _recipeResult;
        public List<GameItemAmountNode> _recipeRequement;
    }
}