using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoseState : State
{
    private const string UI_PATH = "Prefabs/UI/GameState/";
    private GameLoseUI gameLoseUIPrefabs;
    public GameLoseUI gameLoseUI;


    private void Awake()
    {
        gameLoseUIPrefabs = Resources.Load<GameLoseUI>(UI_PATH + "GameLose");
    }

    private void Start()
    {
        gameLoseUI = Instantiate(gameLoseUIPrefabs);
        gameLoseUI.OnReturnClick = GetRewardAndReturn;
    }

    public void GetRewardAndReturn()
    {
        SceneManager.LoadScene("Main");
    }
}
