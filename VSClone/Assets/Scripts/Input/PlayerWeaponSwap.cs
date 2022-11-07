using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponSwap : MonoBehaviour
{
    [SerializeField] private int selectedWeapon = 0;

    private void Start()
    {
        SelectedWeapon();
    }

    private void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }

    public void OnNextWeapon(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }

            SelectedWeapon();
        }
    }

    public void OnPreviousWeapon(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }

            SelectedWeapon();
        }
    }

    public void OnWeaponMenu(InputAction.CallbackContext context)
    {

    }
}
