using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class SwitchTrigger : MonoBehaviour
{
    public GameObject lightingObject; // Optional
    public Material brightMaterial;
    public Material darkMaterial;

    public Renderer floor;
    public Renderer ceiling;
    public Renderer wallLeft;
    public Renderer wallRight;
    public Renderer wallFront;
    public Renderer wallBack;

    private bool isOn = true;

    private void OnEnable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectEntered.AddListener(OnSwitch);
    }

    private void OnDisable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectEntered.RemoveListener(OnSwitch);
    }

    private void OnSwitch(SelectEnterEventArgs args)
    {
        FindObjectOfType<LevelManager>()?.Interact(args.interactorObject.transform.gameObject, gameObject.name);

        isOn = !isOn;

        if (lightingObject != null)
            lightingObject.SetActive(isOn);

        ApplyMaterial(isOn ? brightMaterial : darkMaterial);
        Debug.Log($"[SwitchTrigger] Environment materials changed to {(isOn ? "bright" : "dark")}");
    }

    private void ApplyMaterial(Material mat)
    {
        if (floor != null) floor.material = mat;
        if (ceiling != null) ceiling.material = mat;
        if (wallLeft != null) wallLeft.material = mat;
        if (wallRight != null) wallRight.material = mat;
        if (wallFront != null) wallFront.material = mat;
        if (wallBack != null) wallBack.material = mat;
    }

    public void ResetToOn()
    {
        isOn = true;

        if (lightingObject != null)
            lightingObject.SetActive(true);

        ApplyMaterial(brightMaterial);
        Debug.Log("[SwitchTrigger] Lighting reset to ON");
    }

    public void SetToOff()
    {
        isOn = false;

        if (lightingObject != null)
            lightingObject.SetActive(false);

        ApplyMaterial(darkMaterial);
        Debug.Log("[SwitchTrigger] Lighting turned OFF");
    }
}
