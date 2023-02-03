using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : BaseEnemy
{
    //[SerializeField] private GameObject finishLevelTrigger;

    //Disable behavior tree, play animation

    public override void OnDeath()
    {
        //finishLevelTrigger.SetActive(true);

        base.OnDeath();
    }
}