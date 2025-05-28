using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Condition : LevelCondition
{
    public override void Initialize()
    {
        door.Open(); // starts open
    }

    public override void Interact(GameObject interactor, string source)
    {
        if (source == "step" && interactor.CompareTag("Player"))
        {
            door.Close();
        }
    }
}
