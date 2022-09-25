using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private MouseManager mouseManager;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // Start is called before the first frame update

    private void Awake()
    {
        mouseManager = GetComponentInParent<MouseManager>();
    }
    private void Start()
    {
        mouseManager.OnMouseRight += Shoot;
        mouseManager.OnR += Reload;
    }

    public void Shoot()
    {
        Debug.Log("hi");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void Reload()
    {

    }
}
