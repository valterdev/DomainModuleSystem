using UnityEditor;
using UnityEngine;

namespace OpenGameFramework.Core.Utils
{
    public static class UIEditorUtils
    {
        public static string GetSelectionFolder()
        {
            if (Selection.activeObject != null)
            {
                string path = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());
                if (!string.IsNullOrEmpty(path))
                {
                    int dot   = path.LastIndexOf('.');
                    int slash = Mathf.Max(path.LastIndexOf('/'), path.LastIndexOf('\\'));
                    if (slash > 0)
                        return (dot > slash) ? path.Substring(0, slash) : path;
                }
            }

            return "Assets";
        }
    }
}