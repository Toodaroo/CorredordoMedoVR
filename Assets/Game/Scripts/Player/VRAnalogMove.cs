using UnityEngine;
using UnityEngine.InputSystem;

public class VRAnalogMove : MonoBehaviour
{
    [Header("Referência da câmera VR")]
    public Transform vrCamera;

    [Header("Movimento")]
    public float moveSpeed = 1.2f;
    public float deadZone = 0.15f;

    [Header("Gravidade")]
    public float gravity = -9.81f;
    public float groundedForce = -0.5f;

    [Header("Controle")]
    public bool canMove = true;
    public bool useKeyboardForTest = true;

    private CharacterController characterController;
    private float verticalVelocity = 0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        if (vrCamera == null && Camera.main != null)
            vrCamera = Camera.main.transform;
    }

    private void Update()
    {
        ApplyGravity();

        if (!canMove)
        {
            MoveVerticalOnly();
            return;
        }

        Vector2 input = ReadMoveInput();

        Vector3 horizontalMovement = Vector3.zero;

        if (input.magnitude >= deadZone)
        {
            input = Vector2.ClampMagnitude(input, 1f);

            Vector3 forward = vrCamera != null ? vrCamera.forward : transform.forward;
            Vector3 right = vrCamera != null ? vrCamera.right : transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 moveDirection = (forward * input.y) + (right * input.x);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

            horizontalMovement = moveDirection * moveSpeed;
        }

        Vector3 finalMovement = horizontalMovement;
        finalMovement.y = verticalVelocity;

        if (characterController != null)
        {
            characterController.Move(finalMovement * Time.deltaTime);
        }
        else
        {
            transform.position += finalMovement * Time.deltaTime;
        }
    }

    private void ApplyGravity()
    {
        if (characterController != null && characterController.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = groundedForce;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }

    private void MoveVerticalOnly()
    {
        if (characterController != null)
        {
            Vector3 movement = new Vector3(0f, verticalVelocity, 0f);
            characterController.Move(movement * Time.deltaTime);
        }
    }

    private Vector2 ReadMoveInput()
    {
        Vector2 input = Vector2.zero;

        if (Gamepad.current != null)
        {
            input = Gamepad.current.leftStick.ReadValue();
        }

        if (useKeyboardForTest && Keyboard.current != null)
        {
            Vector2 keyboardInput = Vector2.zero;

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                keyboardInput.y += 1f;

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                keyboardInput.y -= 1f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                keyboardInput.x -= 1f;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                keyboardInput.x += 1f;

            if (keyboardInput != Vector2.zero)
                input = keyboardInput.normalized;
        }

        return input;
    }

    public void StopMovement()
    {
        canMove = false;
    }
}