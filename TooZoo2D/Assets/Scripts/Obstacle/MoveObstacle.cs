using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : Obstacle
{
    float speed = 1f;
    float duration = 3f;
    float count = 0f;

    private void Update()
    {
        if (obstacleTrigger.isTrigger)
        {
            count += Time.deltaTime;
            if (count >= duration)
            {

            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

        }
    }
}
