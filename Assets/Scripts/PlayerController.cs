using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform[] stopObjects; // Array of references to the walls and doors
    public float stopDistance = 2.0f; // Distance at which player should stop
    public LayerMask obstacleLayer; // Layer mask to only consider obstacles
    public KeyCode moveForwardKey = KeyCode.W; // Key to move forward

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    void Update()
    {
        bool shouldStop = false;

        // Check each stop object
        foreach (Transform stopObject in stopObjects)
        {
            // Calculate the vector from the player to the stop object
            Vector3 playerToObject = stopObject.position - transform.position;

            // Check if the stop object is within the stopping distance range
            if (playerToObject.magnitude <= stopDistance)
            {
                // Check if the player is at a 90-degree angle from the stop object
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, obstacleLayer))
                {
                    // Check if the hit object is the stop object
                    if (hit.collider.transform == stopObject)
                    {
                        shouldStop = true;
                        break;
                    }
                }
            }
        }

        if (shouldStop)
        {
            // Stop the player from moving forward
            rb.velocity = Vector3.zero;
        }
        else
        {
            // Check for input to move the player forward
            if (Input.GetKey(moveForwardKey))
            {
                MovePlayer();
            }
            else
            {
                rb.velocity = Vector3.zero; // Stop the player if no input is detected
            }
        }
    }

    void MovePlayer()
    {
        // Example movement code (move forward continuously while key is pressed)
        float moveSpeed = 5.0f;
        rb.velocity = transform.forward * moveSpeed;
    }
}
