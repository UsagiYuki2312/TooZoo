using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class GameStartState : State, IMessageHandle
{
    private const string UI_PATH = "Prefabs/UI/GameState/";
    private const string CHARACTER_PATH = "Prefabs/Character/";
    private GameStartUI gameStartUIPrefabs;
    public GameStartUI gameStartUI;

    private PlayerController playerControllerPrefabs;
    private PlayerController playerController;
    private CatController catControllerPrefabs;
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
        playerControllerPrefabs = Resources.Load<PlayerController>(CHARACTER_PATH + "Player");
        catControllerPrefabs = Resources.Load<CatController>(CHARACTER_PATH + "MeoMeo");

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
        playerController = Instantiate(playerControllerPrefabs);
        Camera.main.GetComponent<CameraFollow>().target = playerController.transform;
        catController = Instantiate(catControllerPrefabs);
        LevelController level = Instantiate(LevelManager.Instance.GetCurrentLevel());
        playerController.SetStatePlayer(PlayerState.Idle);
        catController.SetStateCat(CatState.Idle);

        Vector3 position = level.startPosition.transform.position;
        playerController.transform.position = new Vector3(position.x, playerController.transform.position.y, playerController.transform.position.z);
    }


}
