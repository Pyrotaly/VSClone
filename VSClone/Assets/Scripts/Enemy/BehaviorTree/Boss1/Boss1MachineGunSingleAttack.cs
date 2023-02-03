using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]

public class Boss1MachineGunSingleAttack : EnemyAction
{
    [Header("References")]
    [SerializeField] private HasSpawnProjectile spawner;

    public override void OnStart()
    {
        spawner.Shoot();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }
}
