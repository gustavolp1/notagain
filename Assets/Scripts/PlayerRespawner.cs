using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class PlayerRespawner : MonoBehaviour
{
    [Header("References")]
    public GameObject deathMarkerPrefab;
    public Transform playerSpawnPoint;

    private Queue<GameObject> recentMarkers = new Queue<GameObject>(3);
    private InputDevice rightHand;

    private bool wasButtonPressed = false;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        if (devices.Count > 0)
        {
            rightHand = devices[0];
        }

        if (playerSpawnPoint == null)
        {
            GameObject found = GameObject.FindWithTag("Respawn");
            if (found != null)
                playerSpawnPoint = found.transform;
        }
    }

    void Update()
    {
        if (!rightHand.isValid)
        {
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
            if (devices.Count > 0)
                rightHand = devices[0];
            return;
        }

        bool bPressed = false;
        if (rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bPressed))
        {
            if (bPressed && !wasButtonPressed)
            {
                PlaceMarkerAtFeet();
            }

            wasButtonPressed = bPressed;
        }
    }

    private void PlaceMarkerAtFeet()
    {
        Transform cam = Camera.main.transform;

        Vector3 deathPosition = new Vector3(
            cam.position.x,
            transform.position.y + 0.01f,
            cam.position.z
        );

        if (deathMarkerPrefab != null)
        {
            GameObject newMarker = Instantiate(deathMarkerPrefab, deathPosition, Quaternion.identity);
            recentMarkers.Enqueue(newMarker);
            Debug.Log($"[Respawn] Marker placed at: {deathPosition}");

            if (recentMarkers.Count > 3)
            {
                GameObject oldest = recentMarkers.Dequeue();
                Destroy(oldest);
            }
        }
    }

    public void ClearDeathMarker()
    {
        foreach (var marker in recentMarkers)
        {
            Destroy(marker);
        }

        recentMarkers.Clear();
    }
}
