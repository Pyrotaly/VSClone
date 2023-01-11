using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSpawnItem : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    public void Spawn()
    {
        Instantiate(spawnObject);
    }
}
