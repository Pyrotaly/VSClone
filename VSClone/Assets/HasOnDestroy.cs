using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;

    private void OnDisable()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
    }
}
