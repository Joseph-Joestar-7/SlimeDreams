using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantBase : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected Transform[] moveSpots;
    [SerializeField] protected float waitTimeAtSpot = 5f;
    protected GameObject player;

    protected int currentSpotIndex = 0;
    protected float waitTimer;

    protected Animator animator;
    private bool facingLeft = false;

    private string moveX = "MoveX";
    private string moveY = "MoveY";
    private string lastX = "LastMoveX";
    private string lastY = "LastMoveY";
    private string speedMag = "speedMag";
    protected string attackTrigger = "Attack";

    protected Vector2 direction,movement;
    [SerializeField] protected float attackDistance = 0.5f;
    protected PlantState plantState;

    [SerializeField] private int attackTimeCooldown;
    private float attackTimer;
    [SerializeField] protected int damageValue;
    protected virtual void Start()
    {
        waitTimer = waitTimeAtSpot;
        attackTimer = 0;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        plantState = PlantState.Patrol;
    }

    
    protected virtual void Update()
    {
        switch (plantState)
        {
            case PlantState.Patrol:
                Patrol();
                if(CanSeePlayer(1f))
                {
                    plantState = PlantState.Chase;
                }
                break;
            case PlantState.Chase:
                Chase();
                break;
            case PlantState.Attack:
                Attack();
                break;
            case PlantState.Return:
                break;
                // TODO
        }

        if (direction.x < 0 && !facingLeft)
            Flip();
        else if (direction.x > 0 && facingLeft)
            Flip();

        animator.SetFloat(moveX, direction.x);
        animator.SetFloat(moveY, direction.y);
        animator.SetFloat(speedMag, movement.magnitude / Time.deltaTime);

        if (direction != Vector2.zero)
        {
            animator.SetFloat(lastX, direction.x);
            animator.SetFloat(lastY, direction.y);
        }
        
    }

    protected bool CanSeePlayer(float detectionRange)
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        return distance <= detectionRange;
    }

    protected virtual void Attack()
    {
        attackTimer-= Time.deltaTime;

        if (attackTimer <= 0f)
        {

            animator.SetFloat(lastX, (float)Math.Ceiling(direction.x));
            animator.SetFloat(lastY, (float)Math.Ceiling(direction.y));
            //Debug.Log(direction.x + " " + direction.y);
            //Debug.Log((float)Math.Ceiling(direction.x) + " " + (float)Math.Ceiling(direction.y));

            animator.SetTrigger(attackTrigger);
            
         attackTimer = attackTimeCooldown;
        }
    }

    protected void Chase()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 0.5f)
        {
            plantState = PlantState.Attack;
        }
        else
        {
            direction = (player.transform.position - transform.position).normalized;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, speed * 2 * Time.deltaTime);
            movement = newPosition - (Vector2)transform.position;
            transform.position = newPosition;
        }

    }

    protected void Patrol()
    {
        if (moveSpots.Length == 0) return;

        Transform targetSpot = moveSpots[currentSpotIndex];

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
                animator.SetFloat(speedMag, 0);
            }
        }
        else
        {
            direction = (targetSpot.position - transform.position).normalized;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetSpot.position, speed * Time.deltaTime);
            movement = newPosition - (Vector2)transform.position;
            transform.position = newPosition;
        }        
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }
}
