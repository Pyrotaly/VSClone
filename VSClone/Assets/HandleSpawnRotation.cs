using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSpawnRotation : MonoBehaviour
{
    [SerializeField] private Transform target;              //This script is only for shooting projectile at player...
    private Vector3 directionToPlayer;

    public void MangeRotation()
    {
        Vector2 targetPos = target.position;
        directionToPlayer = targetPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
