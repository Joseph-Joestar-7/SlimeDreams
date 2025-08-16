using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private IA_Player playerInputActions;
    public event EventHandler OnInteractAction;
    public event EventHandler OnUseRockAction;
    private void Awake()
    {
        playerInputActions = new IA_Player();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.UseRock.performed += UseRock_performed;
    }

    private void UseRock_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnUseRockAction?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
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
