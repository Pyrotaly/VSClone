using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Boss12A2 : EnemyAction
{
    [SerializeField] private HasRandomSpawner[] spawners = new HasRandomSpawner[4];

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
