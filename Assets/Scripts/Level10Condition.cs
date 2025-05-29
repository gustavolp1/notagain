using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level10Condition : LevelCondition
{
    public List<GameObject> objectsToDeactivate;

    public override void Initialize()
    {
        if (door != null)
        {
            door.Open();
        }

        foreach (SwitchTrigger switchTrigger in FindObjectsOfType<SwitchTrigger>())
        {
            switchTrigger.SetToOff();
        }

        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        Debug.Log("[Level10] Initialized: Door opened, lights off, objects deactivated.");
    }

    public override void Interact(GameObject interactor, string source)
    {
        Debug.Log("[Level10] Level complete. Reloading scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
