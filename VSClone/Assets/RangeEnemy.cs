using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] private float range;

    [SerializeField] private Transform target;

    [SerializeField] private GameObject enemyBullet;

    //bool playerDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;

        Vector2 direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                //playerDetected = playerDetected ? false : true;
                //Change colors or something

                Debug.Log("Player");
                //If going to shoot player, some visual cue, probably animation
            }
            else
            {
                //playerDetected = playerDetected ? false : true;
                //Change colors or something

                Debug.Log("Nada");
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
