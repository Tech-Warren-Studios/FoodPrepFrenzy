using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjustable movement speed
    public float turnSpeed = 10.0f; // Adjustable turn speed for smooth rotation

    private Rigidbody rb; // Using Rigidbody for physics-based movement
    private Vector3 movement;

    void Start()
    {
        // Get the Rigidbody component for physics-based movement
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from keyboard
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create movement vector
        movement = new Vector3(horizontal, 0, vertical).normalized;

        // Handle rotation only if there's movement
        if (movement.magnitude > 0)
        {
            RotatePlayer();
        }
    }

    void FixedUpdate()
    {
        // Move the player in FixedUpdate for consistent physics update
        MovePlayer();
    }

    void MovePlayer()
    {
        // Calculate the new position
        Vector3 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Apply the movement to the Rigidbody
        rb.MovePosition(newPosition);
    }

    void RotatePlayer()
    {
        // Calculate the rotation towards the movement direction
        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

        // Apply the rotation smoothly
        rb.rotation = Quaternion.Slerp(rb.rotation, toRotation, turnSpeed * Time.fixedDeltaTime);
    }
}


