using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AngleBetweenPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        anim ??= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - player.transform.position;
        Debug.DrawRay(player.transform.position, direction, Color.green);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360f;

        Debug.Log(angle);

        //ManageBossAngle();

        anim.SetFloat("AngleWithPlayer", angle);
    }

    // If I want something to specifically happen at a certain angle
    private void ManageBossAngle()
    {
        switch (angle)
        {
            case < 39:                  // Right of the player
                break;
            case >= 39 and < 90:        // Top right of the player
                break;
            case >= 90 and 135:
                break;
            case >= 135 and < 180:
                break;
            case >= 180 and < 225:
                break;
            case >= 225 and < 270:
                break;
            case >= 270 and < 315:
                break;
            case >= 315 and < 360:
                break;
            case >= 360:
                break;
        }
    }
}
