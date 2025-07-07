using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantBase : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private float waitTimeAtSpot = 1f;

    private int currentSpotIndex = 0;
    private float waitTimer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        waitTimer = waitTimeAtSpot;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Patrol();
    }

    protected void Patrol()
    {
        if (moveSpots.Length == 0) return;

        Transform targetSpot = moveSpots[currentSpotIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetSpot.position) < 0.2f)
        {
            if (waitTimer <= 0f)
            {
                currentSpotIndex = (currentSpotIndex + 1) % moveSpots.Length;
                waitTimer = waitTimeAtSpot;
            }
            else
            {
                waitTimer -= Time.deltaTime;
            }
        }
    }
}
