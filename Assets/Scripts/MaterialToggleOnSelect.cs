using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class MaterialToggleOnSelect : MonoBehaviour
{
    public Material normalMaterial;
    public Material selectedMaterial;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectEntered.AddListener(OnSelect);
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectExited.AddListener(OnDeselect);
    }

    private void OnDisable()
    {
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectEntered.RemoveListener(OnSelect);
        GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>().selectExited.RemoveListener(OnDeselect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        meshRenderer.material = selectedMaterial;
    }

    private void OnDeselect(SelectExitEventArgs args)
    {
        meshRenderer.material = normalMaterial;
    }
}
