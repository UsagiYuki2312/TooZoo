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
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPlay, this);
    }

    private void Start()
    {
        gameStartUI = Instantiate(gameStartUIPrefabs);
    }

    private void OnDisable()
    {
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPlay, this);
    }

}
