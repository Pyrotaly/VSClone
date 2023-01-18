using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunPickup : MonoBehaviour
{
    [SerializeField] private GameObject gunToEnable;
    [SerializeField] private Transform parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (Transform child in parent)
            {
                child.gameObject.SetActive(false);
            }

            // TODO: Play a sound

            Instantiate(gunToEnable, parent);
            Destroy(gameObject);
        }
    }
}
