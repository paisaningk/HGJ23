using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MoveSprite : EditorWindow
    {
        public string path = "Assets/Sprite";
        public string nameAnimation;


        [MenuItem("Tools/Move Sprite")]
        private static void ShowWindow()
        {
            var window = GetWindow<MoveSprite>();
            window.titleContent = new GUIContent("Move Sprite Noob Noob");
            window.Show();
        }

        [Obsolete("Obsolete")]
        private void OnGUI()
        {
            if (GUILayout.Button("Reset", GUILayout.Width(60)))
            {
                path = string.Empty;
                nameAnimation = string.Empty;
            }

            EditorGUILayout.Space(1);

            EditorGUILayout.LabelField("Create Setup Sprite", EditorStyles.boldLabel);

            path = EditorGUILayout.TextField("Path Folder: ", path);

            nameAnimation = EditorGUILayout.TextField("Name Animation", nameAnimation);

            if (GUILayout.Button("Create Folder And Move To Folder"))
            {
                if (!CheckIsFolderHaveExists())
                {
                    AssetDatabase.CreateFolder(path, nameAnimation);
                    AssetDatabase.CreateFolder($"{path}/{nameAnimation}", "Secondary");
                }

                MoveTexture2DToFolderAnimation(path);

                SaveAssetAndPingFolder($"{path}/{nameAnimation}");
            }
        }

        private bool CheckIsFolderHaveExists()
        {
            if (!AssetDatabase.IsValidFolder($"{path}/{nameAnimation}")) return false;
            return true;
        }

        private string GetAnimationPath()
        {
            return $"{path}/{nameAnimation}/";
        }

        private void MoveTexture2DToFolderAnimation(string animationPath)
        {
            var allMaterials =
                AssetDatabase.FindAssets("t: Texture2D", new[] { animationPath });

            foreach (var allMaterial in allMaterials)
            {
                var oldPath = AssetDatabase.GUIDToAssetPath(allMaterial);

                var asset = AssetDatabase.LoadAssetAtPath(oldPath, typeof(Texture2D));

                if (!asset.name.Contains(nameAnimation))
                {
                    continue;
                }

                var newPath = string.Concat(GetAnimationPath(), asset.name, ".png");

                if (string.IsNullOrEmpty(AssetDatabase.ValidateMoveAsset(oldPath, newPath)))
                {
                    AssetDatabase.MoveAsset(oldPath, newPath);
                }
                else
                {
                    Debug.Log($"Failed to move asset from path '{oldPath}' to '{newPath}'.");
                }
            }
        }

        private void SaveAssetAndPingFolder(string path)
        {
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Object));
            Selection.activeObject = obj;
            EditorGUIUtility.PingObject(obj);
            AssetDatabase.Refresh();
        }
    }
}