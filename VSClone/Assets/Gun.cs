using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private MouseManager mouseManager;
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;      //Speed of bullet
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private bool rapidFire;
    private WaitForSeconds rapidFireWait;

    [SerializeField] private int maxAmmo = 1000;
    [SerializeField] private int ammoCostPerShot;
    [SerializeField] private int currentAmmo;

    [SerializeField] private float reloadTime = 2;
    private WaitForSeconds reloadWait;

    Coroutine fireCoroutine;

    private void Awake()
    {
        mouseManager = GetComponentInParent<MouseManager>();
    }

    private void Start()
    {
        rapidFireWait = new WaitForSeconds(1 / fireRate);
        reloadWait = new WaitForSeconds(reloadTime);    

        mouseManager.OnMouseLeftDown += StartFiring;
        mouseManager.OnMouseLeftUp += StopFiring;
        mouseManager.OnR += StartReload;

        currentAmmo = maxAmmo;
    }

    private bool CanShoot()
    {
        return currentAmmo > 0;
    }

    private void StartFiring()
    {
        fireCoroutine = StartCoroutine(RapidFire());
    }

    private void StopFiring()
    {
        Debug.Log("hey");
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
        if (CanShoot())
        {
            currentAmmo -= ammoCostPerShot;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            OnGunShot();
        }
    }

    private void OnGunShot()
    {
        //Put gun effects herer
    }


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
        currentAmmo = maxAmmo;          //TODO : This is not right
        print("done reloading");
    }
}
