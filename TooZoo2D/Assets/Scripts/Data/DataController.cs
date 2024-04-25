using Pixelplacement;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[RequireComponent(typeof(UnityEngine.PlayerLoop.Initialization))]
public class DataController : Singleton<DataController>
{
    private string KEY = "TZ";
    private string dataPath = "";
    public GameData gameData;

    protected override void OnRegistration()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "data.dat");
#if !UNITY_EDITOR
            Application.targetFrameRate=60;
#endif
    }

    public void LoadData()
    {
        if (File.Exists(dataPath))
        {
            // Debug.Log("file exist");
            try
            {
                string data = File.ReadAllText(dataPath);
                string decrypted = XOROperator(data, KEY);
                gameData = JsonUtility.FromJson<GameData>(decrypted);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
                ResetData();
            }
        }
        else
            ResetData();
    }

    public void SaveData()
    {
        string origin = JsonUtility.ToJson(gameData);
        string encrypted = XOROperator(origin, KEY);
        File.WriteAllText(dataPath, encrypted);
    }


    public void ResetData()
    {
        gameData = new GameData();
    }

    private void OnEnable()
    {
        LoadData();
    }

    #region Cryptography

    public static string XOROperator(string input, string key)
    {
        char[] output = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
            output[i] = (char)(input[i] ^ key[i % key.Length]);

        return new string(output);
    }
    #endregion
}

[System.Serializable]
public class GameData
{
    public Collectibles collectibles;
    public LevelData levelData;

    public GameData()
    {
        collectibles = new Collectibles();
        levelData = new LevelData();
    }


}

[System.Serializable]
public class Collectibles
{
    public int gold;
    public int gem;

    public Collectibles()
    {
        gold = 100;
        gem = 2;
    }
}


[System.Serializable]
public class LevelData
{
    public int currentLevel;
    public LevelData()
    {
        currentLevel = 0;
    }
}


