using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Boss1A2 : EnemyAction
{
    [SerializeField] private int bulletsAmount = 10;

    [SerializeField] private float startAngle = 90f, endAngle = 270f;

    private const float radius = 1f;

    public override void OnStart()
    {
        Fire();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            //float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            //float bulDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);

            float bulDirX = this.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float bulDirY = this.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = TestBulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<TestBulletSpawn>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }
}
