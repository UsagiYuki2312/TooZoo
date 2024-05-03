using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Die,
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public Rigidbody2D rigid;
    public Animator anim;
    public PlayerState currentState;
    private void Start()
    {
        defaultSpeed = 3f;
        speed = defaultSpeed;

    }
    public void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:

                break;
            case PlayerState.Run:
                if (!InputManager.Instance.m_HasInput)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                break;
            case PlayerState.Die:
                break;
        }
    }

    public void SetStatePlayer(PlayerState state)
    {
        currentState = state;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPosition"))
        {
            MessageManager.Instance.SendMessage(new Message(TeeMessageType.OnWin));
        }
    }

    public void OnSlowSpeedPlayer()
    {
        speed = defaultSpeed * 0.75f;
    }

    public void OnResetSpeedPlayer()
    {
        speed = defaultSpeed;
    }

}
