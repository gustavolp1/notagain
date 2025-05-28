using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public DoorController door;
    public Transform playerSpawnPoint;
    private LevelCondition levelCondition;
    public int currentLevel = 1;
    public TextMeshProUGUI levelDescriptionText;
    public List<LevelInfo> levelInfos;
    public LevelSelector levelSelector;
    private int highestLevelBeaten = 1;

    void Start()
    {
        if (levelSelector != null)
        {
            levelSelector.maxLevel = 1;
        }
        LoadLevel(currentLevel);
    }

    public void LoadNextLevel()
    {
        ResetAllLights();

        int justCompletedLevel = currentLevel;
        currentLevel++;

        if (justCompletedLevel == highestLevelBeaten)
        {
            highestLevelBeaten++; // unlock one more level

            if (levelSelector != null)
            {
                levelSelector.maxLevel = Mathf.Clamp(highestLevelBeaten, 1, levelInfos.Count);
            }
        }

        LoadLevel(currentLevel);
    }

    public void LoadLevel(int level)
    {
        Debug.Log($"[LevelManager] Loading level {level}");

        currentLevel = level;

        if (levelCondition != null)
        {
            Destroy(levelCondition);
        }

        door.Close();

        switch (level)
        {
            case 1: levelCondition = gameObject.AddComponent<Level1Condition>(); break;
            case 2: levelCondition = gameObject.AddComponent<Level2Condition>(); break;
            case 3: levelCondition = gameObject.AddComponent<Level3Condition>(); break;
            case 4: levelCondition = gameObject.AddComponent<Level4Condition>(); break;
            case 5: levelCondition = gameObject.AddComponent<Level5Condition>(); break;
            default:
                Debug.Log("[LevelManager] No more levels. Restarting from 1.");
                currentLevel = 1;
                ResetAllLights();
                levelCondition = gameObject.AddComponent<Level1Condition>();
                break;
        }

        levelCondition.door = door;
        levelCondition.Initialize();

        ResetPlayerPosition();
        UpdateLevelDescriptionText(level);
    }

    private void ResetPlayerPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && playerSpawnPoint != null)
        {
            player.transform.position = playerSpawnPoint.position;
            player.transform.rotation = playerSpawnPoint.rotation;
        }
    }

    public void Interact(GameObject interactor, string source)
    {
        levelCondition?.Interact(interactor, source);
    }

    private void UpdateLevelDescriptionText(int level)
    {
        if (levelDescriptionText != null && level - 1 < levelInfos.Count)
        {
            LevelInfo info = levelInfos[level - 1];
            string formatted = $"LEVEL {level}\n{info.levelName}\n\n{info.description}";
            levelDescriptionText.text = formatted;
        }
        else
        {
            levelDescriptionText.text = $"LEVEL {level}\nUnknown Level\n\nNo description.";
        }
    }

    public void ResetAllLights()
    {
        foreach (SwitchTrigger switchTrigger in FindObjectsOfType<SwitchTrigger>())
        {
            switchTrigger.ResetToOn();
        }
    }
}
