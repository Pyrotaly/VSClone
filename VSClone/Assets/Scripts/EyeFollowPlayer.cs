using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        EyeFollow();
    }

    private void EyeFollow()
    {
        Vector3 playerPos = player.transform.position;

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y
        );

        transform.up = direction;
    }
}
