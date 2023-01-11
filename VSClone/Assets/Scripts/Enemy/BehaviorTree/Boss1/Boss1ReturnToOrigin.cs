using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]
public class Boss1ReturnToOrigin : EnemyAction
{
    [SerializeField] private Transform target;
    private Vector2 directionToOrigin;

    public override void OnStart()
    {
        ReturnToOrigin();
    }

    private void ReturnToOrigin()
    {
        directionToOrigin = target.position;
    }

    public override TaskStatus OnUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 4 * Time.deltaTime);
        // If stopped moving, then succes
        if (Vector3.Distance(transform.position, target.position) < 0.6)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}
