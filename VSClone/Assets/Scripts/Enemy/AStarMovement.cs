using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStarMovement : MonoBehaviour
{
    public Transform target; // The target position to move towards

    private AIPath aiPath; // Reference to the AIPath component

    private void Start()
    {
        // Get the AIPath component attached to the child object
        aiPath = GetComponentInChildren<AIPath>();
    }

    private void Update()
    {
        // Move the parent sprite object along with the A* object
        if (aiPath.reachedEndOfPath)
        {
            // A* reached the target, perform any necessary logic here
        }

        // Move the sprite object
        if (target != null)
        {
            transform.position = new Vector3(aiPath.position.x, aiPath.position.y, transform.position.z);
            // You can adjust the Z position based on your scene setup if needed
        }
    }
}
