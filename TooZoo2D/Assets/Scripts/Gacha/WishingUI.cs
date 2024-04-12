using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEditor;
using UnityEngine.UI;

public class WishingUI : MonoBehaviour
{
    [Header("CloundsBG1")]
    public GameObject BG1Panel;
    public List<GameObject> clounds;
    public GameObject splash;
    public GameObject star1;
    public GameObject star2;
    public GameObject circleStar1;
    public GameObject circleStar2;

    [Header("Shooting Star")]
    public GameObject shootingStar;
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
            OnStar1Splash();
            OnStar2Splash();
            OnCircleStar2Out();
        }
    }

    public void OnWishButtonDown()
    {
        OnSplashStart();
        OnStar1Splash();
        OnStar2Splash();
        OnCircleStar2Out();
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

    public void OnStar1Splash()
    {
        star1.gameObject.SetActive(true);
        Tween.LocalScale(star1.transform, new Vector3(1f, 1f, 1f), new Vector3(1.5f, 1.5f, 1), 0.5f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, OnStar1Fly, false);
    }

    public void OnStar1Fly()
    {
        Tween.LocalScale(star1.transform, new Vector3(1.5f, 1.5f, 1), new Vector3(0.5f, 0.5f, 1f), 0.75f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, null, false);
    }

    public void OnStar2Splash()
    {
        star2.gameObject.SetActive(true);
        Tween.LocalScale(star2.transform, new Vector3(1f, 1f, 1f), new Vector3(1.5f, 1f, 1f), 0.5f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, OnStar2Fly, false);
    }

    public void OnStar2Fly()
    {
        Tween.LocalScale(star2.transform, new Vector3(1.5f, 1, 1), new Vector3(1f, 1f, 1f), 0.25f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, () => { star2.gameObject.SetActive(false); }, false);
    }

    public void OnCircleStar2Out()
    {
        circleStar2.gameObject.SetActive(true);
        Tween.LocalScale(circleStar2.transform, new Vector3(1.3f, 1.3f, 1.3f), new Vector3(1.5f, 1.5f, 1.5f), 0.75f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, OnCircleStar2In, false);
    }

    public void OnCircleStar2In()
    {

        circleStar2.gameObject.SetActive(true);
        Tween.LocalScale(circleStar2.transform, new Vector3(1.4f, 1.4f, 1.4f), new Vector3(0.45f, 0.45f, 0.45f), 0.5f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, null, false);

        circleStar1.gameObject.SetActive(true);
        Color co = circleStar2.GetComponent<Image>().color;
        Tween.Color(circleStar2.GetComponent<Image>(), co, new Color(co.r, co.g, co.b, 100f / 255f), 0.5f, 0.25f,
                  Tween.EaseInOut, Tween.LoopType.None, null, OnBG1PanelOut, false);
    }

    public void OnBG1PanelOut()
    {
        OnShootingStarZoomOut();
        Tween.LocalPosition(BG1Panel.GetComponent<RectTransform>(), new Vector3(0, 0, 0), new Vector3(-1900, 1500, 0), 1f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, null, false);
    }

    public void OnShootingStarFly()
    {
        Tween.LocalPosition(shootingStar.GetComponent<RectTransform>(), new Vector3(-280, 280, 0), new Vector3(0, 0, 0), 1f, 0,
            Tween.EaseInOut, Tween.LoopType.None, null, null, false);
    }

    public void OnShootingStarZoomOut()
    {
        shootingStar.gameObject.SetActive(true);
        Tween.LocalScale(shootingStar.GetComponent<RectTransform>(), new Vector3(1, 1, 1), new Vector3(3, 3, 3), 0.5f, 0,
           Tween.EaseInOut, Tween.LoopType.None, null, null, false);
    }


    #endregion
}
