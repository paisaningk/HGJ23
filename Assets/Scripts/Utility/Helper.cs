using UnityEditor;
using UnityEngine;

namespace Utility
{
    public static class Helper
    {
        public static void RenameObject(this Object @object, string newName)
        {
            var assetPath = AssetDatabase.GetAssetPath(@object);

            AssetDatabase.RenameAsset(assetPath, newName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public static Sprite GetIconFromPath(string path, string nameIcon)
        {
            var allMaterials = AssetDatabase.FindAssets("t:Sprite", new[] { path });

            foreach (var allMaterial in allMaterials)
            {
                var oldPath = AssetDatabase.GUIDToAssetPath(allMaterial);
                var asset = AssetDatabase.LoadAssetAtPath(oldPath, typeof(Sprite));

                if (asset.name.Contains(nameIcon))
                {
                    return (Sprite)asset;
                }
            }

            Debug.Log("Can't Found Icon");
            return null;
        }
    }
}