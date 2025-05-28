using UnityEngine;

public class CeilingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("[CeilingTrigger] Player touched the ceiling.");
            FindObjectOfType<LevelManager>()?.Interact(other.gameObject, "ceiling");
        }
    }
}
