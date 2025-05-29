using UnityEngine;
using UnityEngine.SceneManagement;

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
                    if (levelManager.GetCurrentLevel() == 10)
                    {
                        Debug.Log("[LevelTrigger] Level 10 complete. Reloading scene.");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                    else
                    {
                        levelManager.LoadNextLevel();
                    }
                }
            }
            else
            {
                Debug.Log("[LevelTrigger] Door is closed. Cannot transition.");
            }
        }
    }
}
