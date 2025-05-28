using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            DoorController door = FindObjectOfType<DoorController>();
            if (door != null && door.IsOpen())
            {
                LevelManager levelManager = FindObjectOfType<LevelManager>();
                if (levelManager != null)
                {
                    levelManager.LoadNextLevel();
                }
            }
            else
            {
                Debug.Log("[LevelTrigger] Door is closed. Cannot transition.");
            }
        }
    }
}
