using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Vector3 lastPosition;

    private void Start()
    {
        // Record the initial position of the player
        lastPosition = transform.position;
    }

    private void Update()
    {
        // No need for collision checking in Update() when using OnTriggerEnter
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as a wall
        if (other.CompareTag("Wall"))
        {
            // If collision detected with a wall, move the player back to the last recorded position
            transform.position = lastPosition;
        }
        else
        {
            // Update the last recorded position if no collision with a wall
            lastPosition = transform.position;
        }
    }
}
