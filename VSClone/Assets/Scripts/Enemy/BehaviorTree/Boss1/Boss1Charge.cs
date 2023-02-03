using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]
[TaskDescription("Boss run fast")]
public class Boss1Charge : EnemyAction
{
    [SerializeField] private float chargeDuration;
    [SerializeField] private float maxSpeed;
    private float originalChargeDuration;
    private float originalSlowDownDistance;
    private float currentSpeed;
    private AIPath aiPath;

    public override void OnAwake()
    {
        base.OnAwake();
        aiPath = GetComponent<AIPath>();
    }

    public override void OnStart()
    {
        originalChargeDuration = chargeDuration;
        currentSpeed = aiPath.maxSpeed;
        aiPath.maxSpeed = maxSpeed;
        aiPath.slowdownDistance = -0.1f;
    }

    public override TaskStatus OnUpdate()
    {
        BaseEnemy baseEnemy = GetComponent<BaseEnemy>();

        if (chargeDuration > 0 && !baseEnemy.collidedWithPlayer)
        {
            chargeDuration -= Time.deltaTime;
            return TaskStatus.Running;
        }
        else
        {
            chargeDuration = originalChargeDuration;
            aiPath.slowdownDistance = originalSlowDownDistance;
            aiPath.maxSpeed = currentSpeed;
            return TaskStatus.Success;
        }
    }
}
