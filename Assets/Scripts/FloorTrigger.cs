using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            Level9Condition level9 = FindObjectOfType<Level9Condition>();
            if (level9 != null)
            {
                level9.PlayerTouchedFloor();
            }
        }
    }
}
