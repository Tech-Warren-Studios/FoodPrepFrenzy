using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // You can adjust this speed in the Unity Inspector

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        // Get the Rigidbody component for physics-based movement
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the horizontal and vertical axes
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Apply the input to the movement vector
        movement = new Vector3(moveX, 0, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Move the player's Rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}


