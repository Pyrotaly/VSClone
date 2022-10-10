using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable //Only used on things who can be damaged: Health -= damageAmount;
{
    void Damage(int damageAmount);
}
