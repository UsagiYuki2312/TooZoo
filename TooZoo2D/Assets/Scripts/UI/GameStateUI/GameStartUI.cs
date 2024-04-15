using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUI : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(StartPlaying);
    }
    private void StartPlaying()
    {
        MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnPlay));
    }
}
