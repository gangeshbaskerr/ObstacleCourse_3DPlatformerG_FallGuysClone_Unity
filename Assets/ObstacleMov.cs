using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMov : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    public float moveDistance = 50f; // Distance to move
    public GameManager gameManager;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingTowardsEnd = true;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player (assuming the player has the "Player" tag)
        if (other.CompareTag("Player"))
        {
            // Call the gameOver method from GameManager
            gameManager.gameOver();
        }
    }

    void Start()
    {
        // Set the start and end positions based on the initial position and move distance
        startPosition = transform.position;
        endPosition = startPosition + transform.right * moveDistance; // Assuming movement along the X-axis
    }

    void Update()
    {
        // Move the obstacle
        if (movingTowardsEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPosition) < 0.01f)
            {
                movingTowardsEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.01f)
            {
                movingTowardsEnd = true;
            }
        }
    }
}
