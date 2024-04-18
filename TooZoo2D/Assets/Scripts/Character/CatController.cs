using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CatState
{
    Idle,
    Chase,
    Find,
    FindComplete,
}
public class CatController : MonoBehaviour
{
    float count;
    float duration = 3;
    public CatState currentState;

    PlayerController playerController;
    FOV fov;

    private void Start()
    {
        currentState = CatState.Idle;
        playerController = FindObjectOfType<PlayerController>();
        fov = GetComponentInChildren<FOV>();
    }
    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case CatState.Idle:
                break;
            case CatState.Chase:
                count += Time.deltaTime;
                if (count >= duration)
                {
                    currentState = CatState.Find;
                    count = 0;
                }
                break;
            case CatState.Find:
                fov.viewRadius += Time.deltaTime * 10;
                fov.viewRadius = Mathf.Clamp(fov.viewRadius, 0, 10);
                if (fov.CheckPlayerVisible())
                {
                    currentState = CatState.Idle;
                    MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnLose));
                }
                if (fov.viewRadius >= 10)
                {
                    currentState = CatState.FindComplete;
                }
                break;
            case CatState.FindComplete:
                if (fov.CheckPlayerVisible())
                {
                    fov.viewRadius = 0;
                    currentState = CatState.Idle;
                    MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnLose));
                }
                else
                {
                    StartCoroutine(OnFindComplete());
                    currentState = CatState.Chase;
                }
                break;
        }
    }

    public void LateUpdate()
    {
        transform.position = new Vector3(playerController.transform.position.x, transform.position.y, transform.position.z);
    }

    IEnumerator OnFindComplete()
    {
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fov.viewRadius = 0;
    }


    public void SetStateCat(CatState state)
    {
        currentState = state;
    }
}
