using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]
public class Boss1ShotGun : EnemyAction
{
    [SerializeField] private int bulletsAmount = 10;
    [SerializeField] private float startAngle = 90f, endAngle = 270f;
    [SerializeField] private HandleSpawnRotation hSR;

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
        hSR.MangeRotation();

        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            //float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            //float bulDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);

            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = -1 * (bulMoveVector - hSR.transform.position).normalized;          //Multiplied by -1 because it go opposite way

            GameObject bul = TestBulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = hSR.transform.position;
            bul.transform.rotation = hSR.transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<TestBulletSpawn>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }
}
