using TMPro;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public int currentLevel = 1;
    public int minLevel = 1;
    public int maxLevel = 10;

    public LevelManager levelManager;

    public void Increment()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel++;
            UpdateText();
        }
    }

    public void Decrement()
    {
        if (currentLevel > minLevel)
        {
            currentLevel--;
            UpdateText();
        }
    }

    public void Confirm()
    {
        if (levelManager != null)
        {
            // Special override for Level 8: use level selector as password input
            if (levelManager.currentLevel == 8)
            {
                var level8 = FindObjectOfType<Level8Condition>();
                if (level8 != null)
                {
                    level8.InputDigit(currentLevel);
                    Debug.Log($"[LevelSelector] Input digit {currentLevel} for password.");
                }
                return;
            }

            int maxAllowedLevel = levelManager.GetHighestLevelBeaten();
            if (currentLevel <= maxAllowedLevel)
            {
                levelManager.ResetAllLights();
                levelManager.LoadLevel(currentLevel);
                FindObjectOfType<PlayerRespawner>()?.ClearDeathMarker();
            }
            else
            {
                Debug.Log($"[LevelSelector] Level {currentLevel} is locked. Highest unlocked: {maxAllowedLevel}");
            }
        }
    }

    private void UpdateText()
    {
        numberText.text = currentLevel.ToString();
    }

    private void Start()
    {
        // Don't overwrite maxLevel here
        UpdateText();
    }
}
