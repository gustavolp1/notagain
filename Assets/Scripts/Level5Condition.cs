using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Condition : LevelCondition
{
    public override void Initialize() { }

    public override void Interact(GameObject interactor, string source)
    {
        if (source != "Button") return;

        if (interactor.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor>() != null)
        {
            door.Open();
        }
    }
}
