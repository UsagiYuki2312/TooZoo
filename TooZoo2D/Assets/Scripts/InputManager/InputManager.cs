using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    float m_InputSensitivity = 1.5f;

    public bool m_HasInput;
    Vector3 m_InputPosition;
    Vector3 m_PreviousInputPosition;

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {

#if UNITY_EDITOR
        m_InputPosition = Mouse.current.position.ReadValue();

        if (Mouse.current.leftButton.isPressed)
        {
            if (!m_HasInput)
            {
                m_PreviousInputPosition = m_InputPosition;
            }
            m_HasInput = true;
        }
        else
        {
            m_HasInput = false;
        }
#else
            if (Touch.activeTouches.Count > 0)
            {
                m_InputPosition = Touch.activeTouches[0].screenPosition;

                if (!m_HasInput)
                {
                    m_PreviousInputPosition = m_InputPosition;
                }
                
                m_HasInput = true;
            }
            else
            {
                m_HasInput = false;
            }
#endif

        if (m_HasInput)
        {
            float normalizedDeltaPosition = (m_InputPosition.x - m_PreviousInputPosition.x) / Screen.width * m_InputSensitivity;
        }
        else
        {

        }

        m_PreviousInputPosition = m_InputPosition;
    }
}
