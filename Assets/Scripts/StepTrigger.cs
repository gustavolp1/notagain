using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTrigger : MonoBehaviour
{
    private GameObject buttonDefault;
    private GameObject buttonActive;
    public AudioClip stepOnSound;
    public AudioClip stepOffSound;

    private bool isPressed = false;

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
            ActivateButton();
            FindObjectOfType<LevelManager>()?.Interact(other.gameObject, "step");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeactivateButton();
        }
    }

    // These methods can be called from anywhere, like Interact()
    public void ActivateButton()
    {
        if (isPressed) return;
        isPressed = true;

        if (buttonDefault != null) buttonDefault.SetActive(false);
        if (buttonActive != null) buttonActive.SetActive(true);

        AudioManager.Instance?.PlayOneShot(stepOnSound);
    }

    public void DeactivateButton()
    {
        if (!isPressed) return;
        isPressed = false;

        if (buttonDefault != null) buttonDefault.SetActive(true);
        if (buttonActive != null) buttonActive.SetActive(false);

        AudioManager.Instance?.PlayOneShot(stepOffSound);
    }
}
