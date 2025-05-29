using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class PlaySoundOnSelect : MonoBehaviour
{
    public AudioClip soundToPlay;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
    }

    private void OnEnable()
    {
        // Use delayed binding to ensure AudioManager is ready
        StartCoroutine(DeferredBind());
    }

    private void OnDisable()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnSelect);
    }

    private System.Collections.IEnumerator DeferredBind()
    {
        yield return null; // Wait one frame to allow scene to finish loading
        if (interactable != null)
            interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("[PlaySoundOnSelect] AudioManager.Instance was null.");
            return;
        }

        AudioManager.Instance.PlayOneShot(soundToPlay);
    }
}
