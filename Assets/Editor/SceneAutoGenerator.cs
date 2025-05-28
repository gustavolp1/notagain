using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

public class SceneAutoGenerator
{
    [MenuItem("Tools/Generate Level Scenes")]
    public static void GenerateScenes()
    {
        string baseScenePath = "Assets/Scenes/SampleScene.unity"; // Template scene
        string outputFolder = "Assets/Scenes/";

        if (!File.Exists(baseScenePath))
        {
            Debug.LogError("Base scene not found at: " + baseScenePath);
            return;
        }

        for (int i = 1; i <= 5; i++)
        {
            string targetScenePath = outputFolder + i + ".unity";

            // Overwrite unconditionally
            if (File.Exists(targetScenePath))
            {
                AssetDatabase.DeleteAsset(targetScenePath);
            }

            FileUtil.CopyFileOrDirectory(baseScenePath, targetScenePath);
            AssetDatabase.ImportAsset(targetScenePath);
            Debug.Log("Created or replaced: " + targetScenePath);
        }

        AssetDatabase.Refresh();
    }
}
