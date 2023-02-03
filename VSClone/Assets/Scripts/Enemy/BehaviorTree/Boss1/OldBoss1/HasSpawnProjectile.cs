using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some redundancy from EnemyHasRangeAttack to make this fit tree node
public class HasSpawnProjectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawnPoint;           //It is gameobjectTransform on player in Hierachy
    [SerializeField] private GameObject enemyBullet;
    private HandleSpawnRotation hSR;

    [Header("Bullet Management")]
    [SerializeField] private float bulletForce = 20f;       //Speed of bullet
    [SerializeField] private float fireRate = 2f;           //Higher number, faster fire rate
    [SerializeField] private int bulletSpreadMinAngle;
    [SerializeField] private int bulletSpreadMaxAngle;

    private void Awake()
    {
        hSR = GetComponent<HandleSpawnRotation>();
    }

    public void Shoot() 
    {
        hSR.MangeRotation();

        //Generate a random angle
        int randomVal = Random.Range(bulletSpreadMinAngle, bulletSpreadMaxAngle);
        Vector3 spread = new Vector3(0, 0, randomVal - 90);

        //directionToPlayer = new Vector3(directionToPlayer.x + spread.z, directionToPlayer.y, directionToPlayer.z + spread.z);
        GameObject bulletIns = Instantiate(enemyBullet, bulletSpawnPoint.position, Quaternion.Euler(bulletSpawnPoint.rotation.eulerAngles + spread)); //bullet will spawn from enemy center
        Rigidbody2D rb = bulletIns.GetComponent<Rigidbody2D>();

        rb.AddForce(bulletIns.transform.up * bulletForce, ForceMode2D.Impulse);
    }

    // TODO: make this fit 8 direction art style in the future...
    //private void MangeRotation()
    //{
    //    Vector2 targetPos = target.position;
    //    directionToPlayer = targetPos - (Vector2)transform.position;
    //    float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;

    //    transform.rotation = Quaternion.Euler(0, 0, angle);
    //}

    private void OnDrawGizmos()
    {
        float rayRange = 6.0f;

        Quaternion upRayRotation = Quaternion.AngleAxis(bulletSpreadMinAngle, Vector3.forward);
        Quaternion downRayRotation = Quaternion.AngleAxis(bulletSpreadMaxAngle, Vector3.forward);

        Vector3 upRayDirection = upRayRotation * transform.right * rayRange;
        Vector3 downRayDirection = downRayRotation * transform.right * rayRange;

        Gizmos.DrawRay(transform.position, upRayDirection);
        Gizmos.DrawRay(transform.position, downRayDirection);
        Gizmos.DrawLine(transform.position + downRayDirection, transform.position + upRayDirection);
    }
}
