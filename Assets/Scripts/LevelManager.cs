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
            levelSelector.maxLevel = 11;
        }
        LoadLevel(currentLevel);
    }

    public void LoadNextLevel()
    {
        ResetAllLights();
        FindObjectOfType<PlayerRespawner>()?.ClearDeathMarker();

        int justCompletedLevel = currentLevel;
        currentLevel++;

        if (justCompletedLevel == highestLevelBeaten)
        {
            highestLevelBeaten++; // unlock one more level

            if (levelSelector != null)
            {
                levelSelector.maxLevel = 11;
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
            case 6: levelCondition = gameObject.AddComponent<Level6Condition>(); break;
            case 7: levelCondition = gameObject.AddComponent<Level7Condition>(); break;
            case 8: levelCondition = gameObject.AddComponent<Level8Condition>(); break;
            case 9: levelCondition = gameObject.AddComponent<Level9Condition>(); break;
            case 10: levelCondition = gameObject.AddComponent<Level10Condition>(); break;
            case 11: levelCondition = gameObject.AddComponent<Level11Condition>(); break;

            default:
                Debug.Log("[LevelManager] No more levels. Restarting from 1.");
                currentLevel = 1;
                ResetAllLights();
                FindObjectOfType<PlayerRespawner>()?.ClearDeathMarker();
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

    public int GetHighestLevelBeaten()
    {
        return highestLevelBeaten;
    }
}
