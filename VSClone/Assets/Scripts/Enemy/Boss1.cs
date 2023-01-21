using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : BaseEnemy
{
    [SerializeField] private GameObject finishLevelTrigger;

    public override void OnDeath()
    {
        finishLevelTrigger.SetActive(true);

        base.OnDeath();
    }
}