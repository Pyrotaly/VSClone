using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileAsset : MonoBehaviour
{
    public static TurretProjectileAsset Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Transform TestArrow;
}
