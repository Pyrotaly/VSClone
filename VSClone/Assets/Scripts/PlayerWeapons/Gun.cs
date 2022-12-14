using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour                  
{
    [Header("References")]
    [SerializeField] private Transform firePoint;           //It is gameobjectTransform on player in Hierachy
    [SerializeField] private GameObject bulletPrefab;
    private MouseManager mouseManager;

    [Header("Bullet Management")]
    [SerializeField] private float bulletForce = 20f;       //Speed of bullet
    [SerializeField] private float fireRate = 2f;           //Higher number, faster fire rate
    [SerializeField] private int bulletSpreadMinAngle;
    [SerializeField] private int bulletSpreadMaxAngle;
    [SerializeField] private bool rapidFire;
    private float nextAttackTime;
    private WaitForSeconds rapidFireWait;

    [Header("Ammo Management")]
    [SerializeField] private int maxAmmo = 1000;
    [SerializeField] private int ammoCostPerShot;
    private int currentAmmo;

    [SerializeField] private float reloadTime = 2;
    private WaitForSeconds reloadWait;

    private Coroutine fireCoroutine;

    private void Awake()
    {
        mouseManager = GetComponentInParent<MouseManager>();
    }

    private void OnEnable()
    {
        rapidFireWait = new WaitForSeconds(1 / fireRate);
        reloadWait = new WaitForSeconds(reloadTime);    

        mouseManager.OnMouseLeftDown += StartFiring;
        mouseManager.OnMouseLeftUp += StopFiring;
        mouseManager.OnR += StartReload;

        currentAmmo = maxAmmo;
    }

    private void OnDisable()
    {
        mouseManager.OnMouseLeftDown -= StartFiring;
        mouseManager.OnMouseLeftUp -= StopFiring;
        mouseManager.OnR -= StartReload;
    }

    private bool CanShoot()
    {
        return currentAmmo > 0;
    }

    private void StartFiring()
    {
        if (Time.time > nextAttackTime)     //Prevent player from spamming attack button
        {
            nextAttackTime = Time.time + (1 / fireRate);
            fireCoroutine = StartCoroutine(RapidFire());
        }
    }

    private void StopFiring()
    {
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private void StartReload()
    {
        StartCoroutine(Reload());
    }

    private void Shoot()
    {   
        currentAmmo -= ammoCostPerShot;

        //Generate a random angle
        int randomVal = Random.Range(bulletSpreadMinAngle, bulletSpreadMaxAngle);
        Vector3 spread = new Vector3(0, 0, randomVal - 90);


        //All guns are pointed upwards, rotation is handled in mouseManager, bullets shoot up relative to gun sprite
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(firePoint.rotation.eulerAngles + spread));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);

        OnGunShot();
    }

    protected abstract void OnGunShot(); //Add gun effects hear

    protected abstract void OnGunReload(); //Add gun reload effects here

    private IEnumerator RapidFire()
    {
        if (CanShoot())
        {
            Shoot();
            if (rapidFire)
            {
                while (CanShoot())
                {
                    Shoot();
                    yield return rapidFireWait;
                }
                StartCoroutine(Reload());
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        if (currentAmmo == maxAmmo)
        {
            yield return null;
        }

        print("reloading");
        yield return reloadWait;
        currentAmmo = maxAmmo;          //TODO : Apparently, something here is not right, need to get ammo from reserve, not just full reload like overwatch?
        print("done reloading");
    }

    private void OnDrawGizmos()
    {
        float rayRange = 6.0f;

        Quaternion upRayRotation = Quaternion.AngleAxis(bulletSpreadMinAngle, Vector3.forward);
        Quaternion downRayRotation = Quaternion.AngleAxis(bulletSpreadMaxAngle, Vector3.forward);

        Vector3 upRayDirection = upRayRotation * transform.right * rayRange;
        Vector3 downRayDirection = downRayRotation * transform.right * rayRange;

        Gizmos.DrawRay(transform.position, upRayDirection);
        Gizmos.DrawRay(transform.position, downRayDirection);
        //Gizmos.DrawLine(transform.position + downRayDirection, transform.position + upRayDirection);
    }
}
