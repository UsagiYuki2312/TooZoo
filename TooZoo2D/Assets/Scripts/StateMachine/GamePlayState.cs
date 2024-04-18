using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayState : State, IMessageHandle
{
    private const string UI_PATH = "Prefabs/UI/GameState/";
    private GamePlayUI gamePlayUIPrefabs;
    public GamePlayUI gamePlayUI;
    private GamePauseUI gamePauseUIPrefabs;
    public GamePauseUI gamePauseUI;
    private PlayerController playerController;
    private CatController catController;

    void IMessageHandle.Handle(Message message)
    {
        switch (message.type)
        {
            case TeeMessageType.OnPause:
                gamePauseUI = Instantiate(gamePauseUIPrefabs);
                this.SetTimeScale(0);
                break;
            case TeeMessageType.OnContinue:
                Destroy(gamePauseUI.gameObject);
                this.SetTimeScale(1);
                break;
            case TeeMessageType.OnQuit:
                this.SetTimeScale(1);
                SceneManager.LoadScene("Main");
                break;
            case TeeMessageType.OnLose:
                playerController.SetStatePlayer(PlayerState.Idle);
                catController.SetStateCat(CatState.Idle);
                ChangeState("GameLoseState");
                break;
            case TeeMessageType.OnWin:
                playerController.SetStatePlayer(PlayerState.Idle);
                catController.SetStateCat(CatState.Idle);
                ChangeState("GameWinState");
                break;
        }
    }

    private void Awake()
    {
        gamePlayUIPrefabs = Resources.Load<GamePlayUI>(UI_PATH + "GamePlay");
        gamePauseUIPrefabs = Resources.Load<GamePauseUI>(UI_PATH + "GamePause");
        playerController = FindObjectOfType<PlayerController>();
        catController = FindObjectOfType<CatController>();

        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPause, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnContinue, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnQuit, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnLose, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnWin, this);
    }

    private void Start()
    {
        gamePlayUI = Instantiate(gamePlayUIPrefabs);
        playerController.SetStatePlayer(PlayerState.Run);
        catController.SetStateCat(CatState.Chase);
    }

    private void OnDisable()
    {
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPause, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnContinue, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnQuit, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnLose, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnWin, this);
    }
}
