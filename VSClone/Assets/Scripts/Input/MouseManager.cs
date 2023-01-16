using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    [Header("Controller Management")]
    [SerializeField] private bool isGamepad;
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float rotateSmoothing = 1000f;

    [Header("Cursor Management")]
    public Camera mainCam;
    private Vector3 worldPos;
    [SerializeField] private float zPosition;
     
        
    public Action OnMouseHover, OnMouseRight, OnMouseLeftDown, OnMouseLeftUp, OnR;

    private Coroutine fireCoroutine;

    private void Awake()
    {
    }

    void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void FixedUpdate()
    {
        HandleGunRotation();
    }

    #region InputHandler
    public void OnRightClickInput(InputAction.CallbackContext context)
    {
        OnMouseRight?.Invoke();
    }

    public void OnLeftClickInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnMouseLeftDown?.Invoke();
        }
        else if (context.canceled)
        {
            OnMouseLeftUp?.Invoke();
        }
    }

    //Reload button
    public void OnRInput(InputAction.CallbackContext context)   //This could be the key R
    {
        if (context.started)
        {
            OnR?.Invoke();
        }
    }
    #endregion

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    public void HandleGunRotation()
    {
        Vector2 lookDir = worldPos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
