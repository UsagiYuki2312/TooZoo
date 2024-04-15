using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinState : State
{
    private const string UI_PATH = "Prefabs/UI/GameState/";
    private GameWinUI gameWinUIPrefabs;
    public GameWinUI gameWinUI;


    private void Awake()
    {
        gameWinUIPrefabs = Resources.Load<GameWinUI>(UI_PATH + "GameWin");
    }

    private void Start()
    {
        gameWinUI = Instantiate(gameWinUIPrefabs);
        gameWinUI.OnReturnClick = GetRewardAndReturn;
    }

    public void GetRewardAndReturn()
    {
        SceneManager.LoadScene("Main");
    }
}
