using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MapObjects
{
    public class ScriptableObjectUtility
    {
        #if UNITY_EDITOR
        public static void CreateAsset<T>()
        {
            var assetType = typeof(T).Name;
            var asset = ScriptableObject.CreateInstance(assetType);

            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == string.Empty)
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != string.Empty)
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), string.Empty);
            }

            var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + assetType + ".asset");

            Debug.Log($"Created new [{assetType}] asset at [{assetPathAndName}]");

            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        #endif
    }
}