using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 1f; //Camera Speed
    public Vector3 offset;

    Vector3 targetPosition;
    private void Awake()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }
    void Start()
    {
        offset = new Vector3(0, 1, 0);
    }
    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        if (transform.position != target.position)
        {
            targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
