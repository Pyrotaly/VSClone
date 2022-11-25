using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpiral : MonoBehaviour
{
    private float angle = 0f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = this.transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = this.transform.position.x + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = TestBulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<TestBulletSpawn>().SetMoveDirection(bulDir);
        }

        angle += 10f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
