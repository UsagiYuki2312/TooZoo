using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleTrigger obstacleTrigger;

    public void Awake()
    {
        obstacleTrigger= GetComponentInChildren<ObstacleTrigger>();
    }

}
