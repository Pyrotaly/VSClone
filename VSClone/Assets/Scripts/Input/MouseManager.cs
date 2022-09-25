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
    private Vector2 aim;

    public Camera mainCam;
    private Vector3 worldPos;

    private Rigidbody2D rb;

    Vector3 testPos;

    [SerializeField] private float zPosition;

    public Action OnMouseHover, OnMouseDown, OnMouseUp;

    //BaseBuildingParameters
    public PlacedObjectTypeSO placeObjectTypeSO;
    public PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;

    //GunManager

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //testPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));    //Used for tile selection

        //TODO : Only for base building
        //transform.position = new Vector3(worldPos.x, worldPos.y, zPosition);          //Exact mouse position, used for changing cursor icon
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = worldPos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnRightClickInput(InputAction.CallbackContext context)
    {

    }

    public void OnLeftClickInput(InputAction.CallbackContext context)
    {

    }

    //While not a mouse button, having base building rotation applied here is good          //Maybe only for base building action map
    public void OnRotateInput(InputAction.CallbackContext context)   //This could be the key R
    {
        dir = PlacedObjectTypeSO.GetNextDir(dir);
    }


    //Checks player device some how???
    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }
}
