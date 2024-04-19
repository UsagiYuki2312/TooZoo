using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    const string PATH = "Prefabs/Level/";
    public List<LevelController> levels = new List<LevelController>();


    protected void Awake()
    {
        InitializePrefabPaths();
    }

    private void InitializePrefabPaths()
    {
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
        levels.Add(Resources.Load<LevelController>(PATH + "Level_01"));
    }

    public LevelController LoadLevelPrefab(int id)
    {
        id = Mathf.Clamp(id, 0, levels.Count - 1);
        return levels[id];
    }

    public void SetNextLevel(int level)
    {
        DataController.Instance.gameData.levelData.currentLevel += 1;
        DataController.Instance.gameData.levelData.currentLevel 
            = Mathf.Clamp(DataController.Instance.gameData.levelData.currentLevel, 0, levels.Count - 1);
        DataController.Instance.SaveData();
    }

    public LevelController GetCurrentLevel()
    {
        int level = DataController.Instance.gameData.levelData.currentLevel;
        level = Mathf.Clamp(level, 0, levels.Count - 1);
        return levels[level];
    }
}
