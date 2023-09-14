using UnityEditor;
using UnityEngine;
using System.IO;
using OpenGameFramework.Core.Utils;

namespace OpenGameFramework.Core.Editor
{
    public static class SOAssetGenerateTool
    {
        [MenuItem("Assets/Create/ScriptableObjects/Create SO Asset")]
        static void CreateDataBindingConverter()
        {
            MonoScript script = Selection.activeObject as MonoScript;
            if (script == null)
                return;
            
            Object asset = ScriptableObject.CreateInstance(script.GetClass());
            if (asset == null)
                return;

            string path = AssetDatabase.GenerateUniqueAssetPath(
                Path.Combine(UIEditorUtils.GetSelectionFolder(), Selection.activeObject.name + ".asset")
            );

            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}