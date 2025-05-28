using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Condition : LevelCondition
{
    private Collider buttonArea;
    private bool doorOpened = false;

    public override void Initialize()
    {
        GameObject buttonObj = GameObject.Find("StepTrigger"); // Adjust name if needed
        if (buttonObj != null)
        {
            buttonArea = buttonObj.GetComponent<Collider>();
        }
    }

    void Update()
    {
        if (doorOpened || buttonArea == null)
            return;

        GameObject[] markers = GameObject.FindGameObjectsWithTag("DeathMarker");

        foreach (GameObject marker in markers)
        {
            Vector3 markerPos = marker.transform.position;
            Vector3 buttonCenter = buttonArea.bounds.center;
            Vector3 buttonSize = buttonArea.bounds.size;

            bool horizontallyOverlapping =
                Mathf.Abs(markerPos.x - buttonCenter.x) < buttonSize.x / 2f &&
                Mathf.Abs(markerPos.z - buttonCenter.z) < buttonSize.z / 2f;

            if (horizontallyOverlapping)
            {
                Debug.Log("[Level6] At least one death marker is above the button. Opening door.");
                door.Open();
                doorOpened = true;
                break;
            }
        }
    }

    public override void Interact(GameObject interactor, string source) { }
}
