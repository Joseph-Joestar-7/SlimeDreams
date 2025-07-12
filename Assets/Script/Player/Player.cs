using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private GameInput gameInput;
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float collisionOffset = 0.02f;
    private ContactFilter2D movementFilter;
    private Vector2 inputVec;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private Animator animator;
    private Vector2 lastMoveDirection=Vector2.down;
    private bool facingLeft = false;

    private string moveX = "MoveX";
    private string moveY = "MoveY";
    private string moveMag = "MoveMagnitude";
    private string lastX = "LastMoveX";
    private string lastY = "LastMoveY";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInput();
        AnimatePlayer();

        if (inputVec.x < 0 && !facingLeft || inputVec.x > 0 && facingLeft)
            Flip();

        HandleMovement();

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);   
    }

    private void ProcessInput()
    {
        inputVec = gameInput.GetMovementVectorNormalized();

        if (inputVec != Vector2.zero)
        {
            lastMoveDirection = inputVec;
        }

    }

    private void AnimatePlayer()
    {
        animator.SetFloat(moveX,inputVec.x); 
        animator.SetFloat(moveY,inputVec.y);
        animator.SetFloat(moveMag,inputVec.sqrMagnitude);
        animator.SetFloat(lastX,lastMoveDirection.x);
        animator.SetFloat (lastY,lastMoveDirection.y);

    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

    private void HandleMovement()
    {
        if (inputVec == Vector2.zero) return;

        bool success = TryMove(inputVec);
        
        if (!success)
        {
            success = TryMove(new Vector2(inputVec.x, 0));
            if (!success)
            {
                success = TryMove(new Vector2(0, inputVec.y));
            }
        }
    }
    private bool TryMove(Vector2 direction)
    {
        float castDistance = moveSpeed * Time.fixedDeltaTime + collisionOffset;
        int hits = rb.Cast(direction, movementFilter, castCollisions, castDistance);

        if (hits == 0)
        {
            Vector2 newPos = rb.position + inputVec * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPos);
            return true;
        }
        else
        {
            return false;
        }
    }
}
