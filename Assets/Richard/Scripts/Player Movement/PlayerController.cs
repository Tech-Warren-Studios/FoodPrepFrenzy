using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; // Degrees per second to rotate

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveX, 0, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Move the player's Rigidbody
        if (movement != Vector3.zero)
        {
            // Move the player
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            // Rotate the player to face the direction of movement
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}



