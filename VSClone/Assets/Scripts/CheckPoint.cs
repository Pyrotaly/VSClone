using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckpointManager cm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Work");
            CheckpointManager.Instance.lastCheckPoint = transform.position;

            Destroy(this);
        }
    }
}
