using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEditor;
using UnityEngine.UI;

public class WishingUI : MonoBehaviour
{
    [Header("CloundsBG1")]
    public List<GameObject> clounds;
    [Header("CloundsBG2")]
    public GameObject splash;
    public GameObject star1;
    public GameObject star2;
    void Start()
    {
        Clounds0FlyIn();
        Clounds1FlyIn();
        Clounds2FlyIn();
        Clounds3FlyIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSplashStart();
        }
    }

    #region Clounds Backround anim
    void Clounds0FlyIn()
    {
        Tween.LocalRotation(clounds[0].gameObject.transform, new Vector3(0, 0, 0), new Vector3(0, 0, -10), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds0FlyOut, false);

    }

    void Clounds0FlyOut()
    {
        Tween.LocalRotation(clounds[0].gameObject.transform, new Vector3(0, 0, -10), new Vector3(0, 0, 0), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds0FlyIn, false);
    }

    void Clounds1FlyIn()
    {
        Tween.LocalRotation(clounds[1].gameObject.transform, new Vector3(0, 0, 25), new Vector3(0, 0, 35), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds1FlyOut, false);

    }

    void Clounds1FlyOut()
    {
        Tween.LocalRotation(clounds[1].gameObject.transform, new Vector3(0, 0, 35), new Vector3(0, 0, 25), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds1FlyIn, false);
    }

    void Clounds2FlyIn()
    {
        Tween.LocalRotation(clounds[2].gameObject.transform, new Vector3(0, 0, -15), new Vector3(0, 0, -25), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds2FlyOut, false);

    }

    void Clounds2FlyOut()
    {
        Tween.LocalRotation(clounds[2].gameObject.transform, new Vector3(0, 0, -25), new Vector3(0, 0, -15), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds2FlyIn, false);
    }

    void Clounds3FlyIn()
    {
        Tween.LocalRotation(clounds[3].gameObject.transform, new Vector3(0, 0, -90), new Vector3(0, 0, -100), 4f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds3FlyOut, false);

    }

    void Clounds3FlyOut()
    {
        Tween.LocalRotation(clounds[3].gameObject.transform, new Vector3(0, 0, -100), new Vector3(0, 0, -90), 2f, 0,
            Tween.EaseLinear, Tween.LoopType.None, null, Clounds3FlyIn, false);
    }
    #endregion

    #region Wish Click
    public void OnSplashStart()
    {
        splash.gameObject.SetActive(true);
        Tween.Color(splash.GetComponent<Image>(), new Color(1f, 1f, 1f, 0), new Color(1f, 1f, 1f, 200f / 255f), 0.75f, 0,
           Tween.EaseInOut, Tween.LoopType.None, null, OnSplashEnd, false);
    }

    public void OnSplashEnd()
    {
        Tween.Color(splash.GetComponent<Image>(), new Color(1f, 1f, 1f, 200f / 255f), new Color(1f, 1f, 1f, 0), 0.5f, 0,
           Tween.EaseInOut, Tween.LoopType.None, null, OnSplashOff, false);
    }

    public void OnSplashOff()
    {
        splash.gameObject.SetActive(false);
    }
    #endregion
}
