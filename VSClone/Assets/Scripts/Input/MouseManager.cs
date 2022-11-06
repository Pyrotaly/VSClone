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
     
        
    public Action OnMouseHover, OnMouseRight, OnMouseLeftDown, OnMouseLeftUp,OnR;

    private Coroutine fireCoroutine;

    private void Awake()
    {
    }

    void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //new Vector3 = testPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));    //Used for tile selection

        //TODO : Only for base building
        //transform.position = new Vector3(worldPos.x, worldPos.y, zPosition);          //Exact mouse position, used for changing cursor icon
    }

    private void FixedUpdate()
    {
        //If not in base building then, not sure if base building in game 
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

    // Rotate button or reload button
    public void OnRInput(InputAction.CallbackContext context)   //This could be the key R
    {
        OnR();
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
