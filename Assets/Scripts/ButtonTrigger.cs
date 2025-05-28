using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class ButtonTrigger : MonoBehaviour
{
    public AudioClip pressSound;


    private void OnEnable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectEntered.AddListener(OnPress);
    }

    private void OnDisable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectEntered.RemoveListener(OnPress);
    }

    private void OnPress(SelectEnterEventArgs args)
    {
        FindObjectOfType<LevelManager>()?.Interact(args.interactorObject.transform.gameObject, gameObject.name);
        AudioManager.Instance?.PlayOneShot(pressSound);
    }
}
