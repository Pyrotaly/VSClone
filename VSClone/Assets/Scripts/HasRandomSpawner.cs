using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temporary Testing Script for Boss1, could be used for Boss2, spawn random things in a circle but not have the items spawn next to each other
public class HasRandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private float radius = 1;
    [SerializeField] private float distanceBetweenSpawnItems = 0.3f;

    private List<Vector3> SpawnedItemsPos = new List<Vector3>();

    public void StartSpawning()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnObjectAtRandom();
        }
    }

    //Might be expensive, before spawning item, checks to see if position of 
    private void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;

        SpawnedItemsPos.Add(randomPos);

        if (SpawnedItemsPos.Count > 1)
        {
            foreach (Vector3 V3Pos in SpawnedItemsPos)
            {
                if (Mathf.Abs(Vector3.Distance(V3Pos, randomPos)) < distanceBetweenSpawnItems)
                {
                    randomPos = Random.insideUnitCircle * radius;
                }
            }
        }

        Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
