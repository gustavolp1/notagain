using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    private GameObject buttonDefault;
    private GameObject buttonActive;

    private void Start()
    {
        Transform parent = transform.parent;
        if (parent != null)
        {
            buttonDefault = parent.Find("ButtonButton")?.gameObject;
            buttonActive = parent.Find("ButtonActive")?.gameObject;
        }

        // Ensure initial state
        if (buttonDefault != null) buttonDefault.SetActive(true);
        if (buttonActive != null) buttonActive.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Visual toggle to pressed state
            if (buttonDefault != null) buttonDefault.SetActive(false);
            if (buttonActive != null) buttonActive.SetActive(true);

            // Send interaction to level manager
            FindObjectOfType<LevelManager>()?.Interact(other.gameObject, "step");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Return to normal state
            if (buttonDefault != null) buttonDefault.SetActive(true);
            if (buttonActive != null) buttonActive.SetActive(false);
        }
    }
}
