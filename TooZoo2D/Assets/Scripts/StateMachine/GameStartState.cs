using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class GameStartState : State, IMessageHandle
{
    private const string UI_PATH = "Prefabs/UI/GameState/";
    private GameStartUI gameStartUIPrefabs;
    public GameStartUI gameStartUI;
    private PlayerController playerController;
    private CatController catController;


    void IMessageHandle.Handle(Message message)
    {
        switch (message.type)
        {
            case TeeMessageType.OnPlay:
                gameStartUI.gameObject.SetActive(false);
                ChangeState("GamePlayState");
                break;
        }
    }

    private void Awake()
    {
        gameStartUIPrefabs = Resources.Load<GameStartUI>(UI_PATH + "GameStart");
        playerController = FindObjectOfType<PlayerController>();
        catController = FindObjectOfType<CatController>();

        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPlay, this);
    }

    private void Start()
    {
        gameStartUI = Instantiate(gameStartUIPrefabs);
        SetPlayerStart();
    }

    private void OnDisable()
    {
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPlay, this);
    }

    private void SetPlayerStart()
    {
        playerController.SetStatePlayer(PlayerState.Idle);
        catController.SetStateCat(CatState.Idle);

        Vector3 position = FindObjectOfType<Level1Controller>().startPosition.transform.position;
        playerController.transform.position = new Vector3(position.x, playerController.transform.position.y, playerController.transform.position.z);
    }

    private void SetMapLevel()
    {

    }

}
