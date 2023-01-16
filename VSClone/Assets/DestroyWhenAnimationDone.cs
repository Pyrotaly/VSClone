using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyWhenAnimationDone : MonoBehaviour
{
    private PlayerWeaponSwap playerWeaponSwap;

    // Expensive?
    private void Awake()
    {
        playerWeaponSwap = GameObject.FindGameObjectWithTag("MouseManager").GetComponent<PlayerWeaponSwap>();
    }
    private void OnEnable()
    {
        playerWeaponSwap.onWeaponSwitch += AnimationDone;
    }

    private void OnDisable()
    {
        playerWeaponSwap.onWeaponSwitch -= AnimationDone;
    }

    private void AnimationDone()
    {
        Destroy(this.gameObject);
    }
}
