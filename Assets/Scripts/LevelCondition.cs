using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelCondition : MonoBehaviour
{
    public DoorController door;

    public abstract void Initialize();
    public abstract void Interact(GameObject interactor, string source);
}