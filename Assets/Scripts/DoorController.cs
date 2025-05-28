using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Material closedMaterial;
    public Material openMaterial;
    public Renderer doorRenderer;
    public AudioClip openSound;

    private bool isOpen = false;

    public void Open()
    {
        if (!isOpen) // Only play if it was previously closed
        {
            AudioManager.Instance?.PlayOneShot(openSound);
        }
        Debug.Log("Door opened!");
        doorRenderer.material = openMaterial;
        isOpen = true;
    }

    public void Close()
    {
        doorRenderer.material = closedMaterial;
        isOpen = false;
    }

    public bool IsOpen() => isOpen;
}