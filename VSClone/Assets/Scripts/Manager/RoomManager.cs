using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private List<GameObject> enemyList;
    private int enemyCount;

    private void OnEnable()
    {
        ActionsHolder.OnEnemyKilled += OnEnemyDeath;
    }

    private void OnDisable()
    {
        ActionsHolder.OnEnemyKilled -= OnEnemyDeath;
    }

    private void Start()
    {
        enemyCount = enemyList.Count;
    }

    private void OnEnemyDeath()
    {
        enemyCount--;

        if (enemyCount == 0)
        {
            // TODO: Make a sound on door destroyed
            Instantiate(deathParticle, door.transform.position, Quaternion.identity);
            Destroy(door);
            Destroy(this);
        }
    }
}