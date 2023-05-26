using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHasAngleOrientedAnimations : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;
    private float angle;

    private void Start()
    {
        anim ??= GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 direction = transform.position - player.transform.position;
        Debug.DrawRay(player.transform.position, direction, Color.green);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360f;
        Debug.Log(angle);

        // Set the "PlayerAngle" parameter in the Animator
        anim.SetFloat("PlayerAngle", angle);
    }
}
