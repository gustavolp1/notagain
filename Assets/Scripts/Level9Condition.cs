using UnityEngine;

public class Level9Condition : LevelCondition
{
    private bool hasFailed = false;

    public override void Initialize()
    {
        if (door != null)
        {
            door.Open(); // Start open
        }
    }

    public void PlayerTouchedFloor()
    {
        if (!hasFailed)
        {
            hasFailed = true;
            Debug.Log("[Level9Condition] Player stepped on the floor. Closing door.");
            if (door != null)
            {
                door.Close();
            }
        }
    }

    public override void Interact(GameObject interactor, string source) { }
}
