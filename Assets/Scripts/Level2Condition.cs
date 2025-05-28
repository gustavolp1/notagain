using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Condition : LevelCondition
{
    private int stepCount = 0;

    public override void Initialize()
    {
        stepCount = 0;
    }

    public override void Interact(GameObject interactor, string source)
    {
        if (source == "step" && interactor.CompareTag("Player"))
        {
            stepCount++;
            Debug.Log($"[Level2] Step count: {stepCount}");
            if (stepCount >= 3)
                door.Open();
        }
    }
}