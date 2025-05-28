using UnityEngine;

public class Level7Condition : LevelCondition
{
    private bool ceilingTouched = false;

    public override void Initialize()
    {
        ceilingTouched = false;
    }

    public override void Interact(GameObject interactor, string source)
    {
        if (!ceilingTouched && source == "ceiling")
        {
            ceilingTouched = true;
            Debug.Log("[Level7Condition] Ceiling interaction detected. Opening door.");
            door.Open();
        }
    }
}
