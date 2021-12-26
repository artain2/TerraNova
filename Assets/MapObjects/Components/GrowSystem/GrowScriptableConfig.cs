using UnityEditor;

namespace MapObjects.Components
{
    public class GrowScriptableConfig : ScriptableObjectContainer<GrowComponent.GrowConfig>
    {
        public float GrowSpeed;
        
        
        
#if UNITY_EDITOR
        [MenuItem("Assets/Create/Configs/" + nameof(GrowComponent.GrowConfig))]
        public static void CreateAsset()
        {
            ScriptableObjectUtility.CreateAsset<GrowScriptableConfig>();
        }
#endif
    }
}