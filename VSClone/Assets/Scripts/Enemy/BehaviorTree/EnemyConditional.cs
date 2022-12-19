using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class EnemyConditional : Conditional
{
    protected Rigidbody2D rb2D;
    protected Animator animator;

    public override void OnAwake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
