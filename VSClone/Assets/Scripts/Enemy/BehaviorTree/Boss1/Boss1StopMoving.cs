using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]
[TaskDescription("Stop Moving Boss")]
public class Boss1StopMoving : EnemyAction
{
    private AIPath aiPath;

    public override void OnAwake()
    {
        base.OnAwake();
        aiPath = GetComponent<AIPath>();
    }

    public override void OnStart()
    {
        aiPath.canMove = false;
    }

    public override TaskStatus OnUpdate()
    { 
        aiPath.canMove = true;
        return TaskStatus.Running;
    }
}
