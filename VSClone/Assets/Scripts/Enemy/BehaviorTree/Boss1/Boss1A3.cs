using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]
public class Boss1A3 : EnemyAction
{
    private float angle = 0f;

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
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);  //Writes X vector of bullet, starting x position + sin(angle of i) //this.transform.position.x + 
            float bulDirY = Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);  //Writes Y vector of bullet, starting y position + cos(angle of i) //this.transform.position.x + 

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector).normalized;                        // - transform.position

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