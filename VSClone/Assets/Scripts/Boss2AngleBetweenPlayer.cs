using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AngleBetweenPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = -this.transform.position + player.transform.position;
        Debug.DrawRay(player.transform.position, direction, Color.green);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360f;

        Debug.Log(angle);

        ManageBossAngle();
    }

    private void ManageBossAngle()
    {
        switch (angle)
        {
            case < 45:
                break;
            case >= 45 and <= 90:
                break;
        }
    }
}
