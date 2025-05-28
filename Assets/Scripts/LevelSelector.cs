using TMPro;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public int currentLevel = 1;
    public int minLevel = 1;
    public int maxLevel = 1; // Initial max level

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
            levelManager.ResetAllLights();
            levelManager.LoadLevel(currentLevel);
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
