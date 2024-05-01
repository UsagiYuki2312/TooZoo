using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CatState
{
    Idle,
    Chase,
    Find,
    Detect,
    FindComplete,
}
public class CatController : MonoBehaviour
{
    float count;
    float duration = 3f;
    float delay = 0.5f;
    public CatState currentState;

    PlayerController playerController;
    FOV fov;

    bool corou_complete;
    bool corou_start;
    private void Start()
    {
        currentState = CatState.Idle;
        playerController = FindObjectOfType<PlayerController>();
        fov = GetComponentInChildren<FOV>();
        corou_complete = false;
        corou_start = false;
        transform.position = new Vector3(playerController.transform.position.x, -1f, transform.position.z);
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
                if (transform.position.y < 1.8f)
                {
                    transform.position += new Vector3(0, 5 * Time.deltaTime, 0);
                }
                else
                {
                    currentState = CatState.Detect;
                }
                break;
            case CatState.Detect:
                count += Time.deltaTime;
                if (count <= delay)
                {
                    return;
                }
                fov.viewRadius += Time.deltaTime * 5;
                fov.viewRadius = Mathf.Clamp(fov.viewRadius, 0, 10);
                if (fov.CheckPlayerVisible())
                {
                    currentState = CatState.Idle;
                    MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnLose));
                    count = 0;
                }
                if (fov.viewRadius >= 10)
                {
                    currentState = CatState.FindComplete;
                    count = 0;
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
                    if (corou_start == false && !corou_complete)
                    {
                        StartCoroutine(OnFindComplete());
                    }
                    if (corou_complete)
                    {
                        transform.position -= new Vector3(0, 10 * Time.deltaTime, 0);
                        if (transform.position.y <= -1f)
                        {
                            corou_start = false;
                            corou_complete = false;
                            currentState = CatState.Chase;
                        }
                    }

                }

                break;
        }
    }

    public void LateUpdate()
    {
        float y = Mathf.Clamp(transform.position.y, -1f, 1.8f);
        transform.position = new Vector3(playerController.transform.position.x, y, transform.position.z);
    }

    IEnumerator OnFindComplete()
    {
        corou_start = true;
        yield return new WaitForSeconds(0.5f);
        fov.fieldOfView.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        fov.fieldOfView.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fov.viewRadius = 0;
        yield return new WaitForSeconds(0.2f);
        corou_complete = true;

    }

    IEnumerator OnFindStart()
    {
        yield return new WaitForSeconds(0.5f);
    }


    public void SetStateCat(CatState state)
    {
        currentState = state;
    }
}
