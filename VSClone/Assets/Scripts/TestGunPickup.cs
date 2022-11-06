using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunPickup : MonoBehaviour
{
    [SerializeField] private GameObject gunToEnable;
    [SerializeField] private Transform parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gunToEnable, parent);
    }
}
