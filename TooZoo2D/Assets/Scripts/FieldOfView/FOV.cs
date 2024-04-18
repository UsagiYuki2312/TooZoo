using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float viewRadius = 5;
    public float viewAngle = 135;
    Collider2D[] playerInRadius;
    public LayerMask obstacleMask, playerMask;
    public List<Transform> visiblePlayer = new List<Transform>();
    public FieldOfView fieldOfView;

    private void Start()
    {
        fieldOfView = GetComponentInChildren<FieldOfView>();
        viewRadius = 0;
        viewAngle = 120f;
    }
    private void FixedUpdate()
    {
        FindVisiblePlayer();
    }

    void FindVisiblePlayer()
    {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius);

        visiblePlayer.Clear();

        for (int i = 0; i < playerInRadius.Length; i++)
        {
            Transform player = playerInRadius[i].transform;
            Vector2 dirTarget = player.position - transform.position;
            if (Vector2.Angle(dirTarget, transform.right) < viewAngle / 2)
            {
                float distancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirTarget, distancePlayer, obstacleMask))
                {
                    visiblePlayer.Add(player);
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }

    public bool CheckPlayerVisible()
    {
        foreach (Transform player in visiblePlayer)
        {
            if (player.gameObject.CompareTag("Player")){
                return true;
            }
        }
        return false;
    }
}
