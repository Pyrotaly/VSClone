using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateToTarget : MonoBehaviour
{
    public float speed;
    private Vector2 direction;

    private Vector3 worldPos;

    private void Update()
    {
        worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        direction = worldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}