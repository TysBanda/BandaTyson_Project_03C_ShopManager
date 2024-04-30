using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Movement speed of the player
    public float moveSpeed = 5f;

    void Update()
    {
        // Check for horizontal movement (WASD keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Check for vertical movement (WASD keys)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player based on the input
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }
}
