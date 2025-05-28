using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Condition : LevelCondition
{
    private bool lightsOn = true;

    public override void Initialize() { }

    public override void Interact(GameObject interactor, string source)
    {
        if (source != "Lightswitch Left" && source != "Lightswitch Right") return;

        lightsOn = !lightsOn;
        Debug.Log("[Level3] Lights toggled. Lights are now " + (lightsOn ? "ON" : "OFF"));

        if (!door.IsOpen())
        {
            door.Open();
        }
    }
}
    