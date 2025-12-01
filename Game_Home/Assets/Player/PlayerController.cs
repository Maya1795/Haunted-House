using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float runSpeed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    public Transform cameraTransform;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoveAndJump(); // combined horizontal + vertical movement
    }

    void MoveAndJump()
    {
        // Horizontal movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = cameraTransform.forward * z + cameraTransform.right * x;
        move.y = 0f;
        move.Normalize();

        // Adjust speed for running
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        move *= currentSpeed;

        // Ground check
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f; // keep grounded

            // Jump input
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = move + new Vector3(0, velocity.y, 0);
        controller.Move(finalMove * Time.deltaTime);
    }
}
