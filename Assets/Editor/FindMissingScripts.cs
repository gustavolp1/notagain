using UnityEngine;
using UnityEditor;

public class FindMissingScripts : MonoBehaviour
{
    [MenuItem("Tools/Find Missing Scripts in Scene")]
    static void Find()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject go in objects)
        {
            Component[] components = go.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.Log($"Missing script in: {GetFullPath(go)}", go);
                    count++;
                }
            }
        }

        Debug.Log($"Found {count} missing scripts in the scene.");
    }

    static string GetFullPath(GameObject obj)
    {
        string path = obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = obj.name + "/" + path;
        }
        return path;
    }
}
