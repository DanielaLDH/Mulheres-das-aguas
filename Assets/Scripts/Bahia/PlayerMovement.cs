
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private float verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        if (moveAction != null)
            moveAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null)
            moveAction.action.Disable();
    }

    private void Update()
    {
        if (moveAction == null)
            return;

        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Movimentação nos eixos X/Z do mundo (provisória).
        Vector3 movement = new Vector3(input.x, 0f, input.y);

        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;

        movement = movement * moveSpeed;
        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}
