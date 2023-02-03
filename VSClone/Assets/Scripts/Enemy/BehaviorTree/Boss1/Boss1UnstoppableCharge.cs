using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss1")]
[TaskDescription("Moving Boss")]
public class Boss1UnstoppableCharge : EnemyAction
{
    [SerializeField] private Transform target;  //I think can directly refernce from editor, won't slow game too much
    private Vector2 directionToTarget;
    private AIPath aiPath;
    private bool touchedWall;

    public override void OnAwake()
    {
        base.OnAwake();
        aiPath = GetComponent<AIPath>();
    }

    public override void OnStart()
    {
        aiPath.canMove = false;
        Charge();
    }

    private void Charge()
    {
        // TODO: Draw a line signally where enemy chargin?? or set animation...
        directionToTarget = target.position;
        rb2D.velocity = 5 * directionToTarget;
    }

    public override TaskStatus OnUpdate()
    {
        // If stopped moving, then succes
        if (touchedWall)
        {
            Debug.Log("TouchedWall");
            rb2D.velocity = Vector2.zero;
            touchedWall = false;
            aiPath.canMove = true;
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        // If collide with layer 7, impassible or walls...
        if (collision.gameObject.layer == 7)
        {
            touchedWall = true;
        }
    }
}
