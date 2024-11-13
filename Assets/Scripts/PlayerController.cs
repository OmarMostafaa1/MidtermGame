using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Speed at which the player moves.
    public float speed = 5f;

    // Flag to control if the player can move
    private bool canMove = true;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()
    {
        // Only allow movement if canMove is true
        if (canMove)
        {
            // Get movement inputs from the default Input Manager
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Create a movement vector
            Vector3 movement = new Vector3(moveX, 0.0f, moveZ) * speed;

            // Apply force to the Rigidbody to move the player
            rb.AddForce(movement);
        }
    }

    // Method to disable player movement
    public void DisableMovement()
    {
        canMove = false; // Disable movement when the game ends
    }

    // Optional: Reset movement for debugging purposes
    public void EnableMovement()
    {
        canMove = true; // Enable movement again if needed
    }
}
