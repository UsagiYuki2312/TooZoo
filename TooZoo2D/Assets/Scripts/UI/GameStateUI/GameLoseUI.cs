using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameLoseUI : MonoBehaviour
{
    public Button noThank;
    public UnityAction OnReturnClick;
    public UnityAction OnAdsButtonClick;

    public void Start()
    {
        noThank.onClick.AddListener(OnReturnClick);
    }
    public void OnReturn()
    {
        OnReturnClick?.Invoke();

    }
}
