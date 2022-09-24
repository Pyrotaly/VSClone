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

    Vector3 testPos;

    [SerializeField] private float zPosition;

    public Action OnMouseHover, OnMouseDown, OnMouseUp;

    //BaseBuildingParameters
    public PlacedObjectTypeSO placeObjectTypeSO;
    public PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;

    //GunManager

    void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //testPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));    //Used for tile selection

        //TODO : Only for base building
        //transform.position = new Vector3(worldPos.x, worldPos.y, zPosition);          //Exact mouse position, used for changing cursor icon
        HandleRotation();
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

    //TODO : I think HandleRotation and LookAt involve 3d looking which is not needed perhaps
    private void HandleRotation()
    {
        if (isGamepad)
        {
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, rotateSmoothing * Time.deltaTime);
                }
            }
        }
        else
        {
            Debug.Log("hi");
            Ray ray = Camera.main.ScreenPointToRay(aim);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectPoint);
    }

}
