using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Condition : LevelCondition
{
    public override void Initialize() { }

    public override void Interact(GameObject interactor, string source)
    {
        if (source == "step" && interactor.CompareTag("Player"))
        {
            door.Open();
        }
    }
}

