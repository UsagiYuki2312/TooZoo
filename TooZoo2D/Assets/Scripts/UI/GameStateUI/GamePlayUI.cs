using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public Button settingButton;

    void Start()
    {
        settingButton.onClick.AddListener(OnPause);
    }
    public void OnPause()
    {
        MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnPause));
    }
}
