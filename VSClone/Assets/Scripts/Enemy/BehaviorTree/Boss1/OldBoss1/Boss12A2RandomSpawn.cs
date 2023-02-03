using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;


//Boss move that spawns missiles or enemies
[TaskCategory("BossX")]
[TaskDescription("SpawnAttack")]
public class Boss12A2RandomSpawn : EnemyAction
{
    [SerializeField] private HasRandomSpawner[] spawners; // = new HasRandomSpawner[4];

    public override void OnStart()
    {
        foreach(HasRandomSpawner spawner in spawners)
        {
            spawner.StartSpawning();
        }
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }
}
