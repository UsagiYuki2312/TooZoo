using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    public Button quitBtn;
    public Button continueBtn;
    public void Start()
    {
        quitBtn.onClick.AddListener(OnQuit);
        continueBtn.onClick.AddListener(OnContinue);
    }
    public void OnQuit()
    {
        MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnQuit));
    }

    public void OnContinue()
    {
        MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnContinue));

    }
}
