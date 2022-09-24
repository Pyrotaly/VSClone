using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
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
        transform.position = new Vector3(worldPos.x, worldPos.y, zPosition);          //Exact mouse position, used for changing cursor icon
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
}
