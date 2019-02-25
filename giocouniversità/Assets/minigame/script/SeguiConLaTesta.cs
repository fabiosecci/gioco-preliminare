using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguiConLaTesta : MonoBehaviour {

    private Transform player;
    private RaycastHit hitPlayer, left, right, forLeft, forRight;
    private Rigidbody rb;
    private GameObject[] lastPositions;
    private GameObject closestPosition;

    public bool playerSpotted;
    public float rangeVision = 50f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").transform; // Find the player GameObject
        rb = GetComponent<Rigidbody>();    
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        EnemyVision(); 
        HeadMove(); 
    }


    void EnemyVision()
    {

        if (Physics.Linecast(transform.position, player.position, out hitPlayer)) // Linecast towards the player ignoring the last position layer
        {
            Debug.Log("1");
            if (hitPlayer.collider.tag == "Player") // if the raycast hits the player then continue
            {
                Debug.Log("2");
                if (Vector3.Distance(transform.position, player.position) < rangeVision)// If the distance from the player is minore than a number then continue
                {
                    Debug.Log("3");
                    playerSpotted = true; // Player has been spotted
                    Debug.DrawLine(transform.position, hitPlayer.point, Color.red); //Draw a red line from the enemy to the player
                    EnemyRotate(player.position);
                }
                else
                {
                    playerSpotted = false; // Player has not been spotted
                    Debug.Log("0");
                }
            }
        }

    }


    void HeadMove()
    {
        if (playerSpotted) // If the player has been spotted then continue
        {
            if (Vector3.Distance(transform.position, player.position) > 2) // If the distance from the player is greater than a number then continue
            {
                EnemyRotate(player.position); // Calls the rotate function sending the players position

            }
            

        }
        else if (FindLastPosition() != null&&(Vector3.Distance(transform.position, player.position) < rangeVision)) // If the player has NOT been spotted and a last position has been found then continue **FindLastPosition() returns a GameObject
            {
                EnemyRotate(FindLastPosition().transform.position);
            }

    }

    private GameObject FindLastPosition()
    {
        lastPositions = GameObject.FindGameObjectsWithTag("LastPosition"); // Find all game objects with a tag
        float distance = rangeVision; // set a float for an infinit distance this (this can be changed to a distance value)

        for (int i = 0; i < lastPositions.Length; i++) // For every lastPositions that was found with the above tag
        {
            RaycastHit hitLastPos;
            if (Physics.Raycast(transform.position, lastPositions[i].transform.position - transform.position, out hitLastPos)) // Cast a line from the Ai to the next lastPosition in sequence
            {
                if (hitLastPos.collider.tag == "LastPosition") // If the raycast hits a game object with a tag then continue
                {
                    Vector2 diff = lastPositions[i].transform.position - player.position; // Set a vector distance from the last position to the player
                    float curDistance = diff.sqrMagnitude; // Apply squared magnitude to the vector for distance comparison
                    if (curDistance < distance) // If the current distance from the last position is less than the set distance
                    {
                        closestPosition = lastPositions[i]; // Set the closestPosition game object to equal the last position that has been found
                        distance = curDistance; // Set the distance to the current distance
                    }
                }
            }
        }
        return closestPosition; // Return the closestPosition game object that was found
    }


    private void EnemyRotate(Vector3 position)
        {
            rb.MoveRotation(Quaternion.LookRotation(position - transform.position)); // Rotate the enemy to look towards the players position
        }
}
