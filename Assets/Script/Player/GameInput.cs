using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private IA_Player playerInputActions;

    private void Awake()
    {
        playerInputActions = new IA_Player();
        playerInputActions.Player.Enable();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
