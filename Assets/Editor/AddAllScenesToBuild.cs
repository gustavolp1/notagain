using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class AddAllScenesToBuild
{
    [MenuItem("Tools/Add All Scenes to Build Settings")]
    public static void AddScenes()
    {
        string[] scenePaths = Directory.GetFiles("Assets/Scenes", "*.unity", SearchOption.AllDirectories);

        EditorBuildSettingsScene[] newScenes = scenePaths
            .Select(path => new EditorBuildSettingsScene(path, true))
            .ToArray();

        EditorBuildSettings.scenes = newScenes;

        Debug.Log($"[BuildSettings] {newScenes.Length} scenes added to Build Settings.");
    }
}
