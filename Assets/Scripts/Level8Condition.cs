using System.Collections.Generic;
using UnityEngine;

public class Level8Condition : LevelCondition
{
    private List<int> inputSequence = new List<int>();
    private readonly int[] correctPassword = { 7, 8, 9 };

    public void InputDigit(int digit)
    {
        inputSequence.Add(digit);
        if (inputSequence.Count > correctPassword.Length)
            inputSequence.RemoveAt(0);

        Debug.Log("[Level8Condition] Sequence: " + string.Join(",", inputSequence));

        if (IsPasswordCorrect())
        {
            Debug.Log("[Level8Condition] Correct password entered. Opening door.");
            if (door != null)
                door.Open();
        }
    }

    private bool IsPasswordCorrect()
    {
        if (inputSequence.Count != correctPassword.Length)
            return false;

        for (int i = 0; i < correctPassword.Length; i++)
        {
            if (inputSequence[i] != correctPassword[i])
                return false;
        }
        return true;
    }

    public override void Initialize() { }

    public override void Interact(GameObject interactor, string source) { }
}
