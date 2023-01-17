using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note this was the old 
public class SpawnEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemyArray)
            {
                enemy.SetActive(true);
            }

            Destroy(this);
        }
    }
}
