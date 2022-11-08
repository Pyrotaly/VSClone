using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float shootRange = 6;
    [SerializeField] private float attackCooldown = 2f;
    private float nextAttackTime;
    private Vector2 directionToPlayer;

    void Update()
    {
        CheckCanShootPlayer();
    }

    private void CheckCanShootPlayer()
    {
        Vector2 targetPos = target.position;

        directionToPlayer = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, directionToPlayer, shootRange);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                //playerDetected = playerDetected ? false : true;
                //Change colors or something

                Debug.Log("Player");
                //If going to shoot player, some visual cue, probably animation
                if (Time.time > nextAttackTime) { Shoot(); }
            }
        }
    }

    //Make this an interface or reusable?
    public void Shoot()
    {
        GameObject bulletIns = Instantiate(enemyBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //bullet will spawn from enemy center
        Rigidbody2D rb = bulletIns.GetComponent<Rigidbody2D>();
        rb.AddForce(directionToPlayer * bulletForce, ForceMode2D.Impulse);
        nextAttackTime = Time.time + attackCooldown;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootRange);
        Gizmos.DrawLine(transform.position, target.position);
    }
}
 