using System.IO;
using UnityEngine;

namespace OpenGameFramework.Core.Utils.Editor
{
    public static partial class EditorHelpers
    {
        public static void WriteFileBaseOnTemplate(string tmplPath, string filePath, string fileName, string[] replaceStrings)
        {
            string tmpl = File.ReadAllText(Path.Combine(Application.dataPath, tmplPath));
            
            for (int i = 0; i < replaceStrings.Length; i++)
            {
                tmpl = tmpl.Replace($"{{{i}}}", replaceStrings[i]);
            }

            File.WriteAllText(Path.Combine(Application.dataPath, filePath, fileName), tmpl);
        }
    }
}