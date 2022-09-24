using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseBuildTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler 
{
    //FurnitureList? will directly alter what placedObjectTypeSO is
    public PlacedObjectTypeSO placeObjectTypeSO;
    private PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;

    private PlacedObject placedObject;

    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;

    public int x;
    public int y;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
        
    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    public bool CanBuild() { return placedObject == null; }

    public void ClearPlacedObject() { placedObject = null; }

    public void SetPlacedObject(PlacedObject placedObject) { this.placedObject = placedObject; }


    //Controller could use virtual mouse to use the OnPointer events
    #region MouseLogic
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }
  
    public void OnPointerDown(PointerEventData eventData)
    {  
        List<Vector2Int> gridPositionList = placeObjectTypeSO.GetGridPositionList(new Vector2Int(x, y), dir); //first parameter gets this tile position

        #region HandlePlacement
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Checks if any space when placing a new object is already occupied and then won't let player place
            bool canBuild = true;
            foreach (Vector2Int gridPosition in gridPositionList)
            {
                if (!GridManager.instance.GetTileAtPosition(gridPosition).CanBuild())
                {
                    canBuild = false;
                    break;
                } 
            }
    
            if (canBuild)
            {
                PlacedObject placedObject = PlacedObject.Create(new Vector3(x, y), dir, placeObjectTypeSO);
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    GridManager.instance.GetTileAtPosition(gridPosition).SetPlacedObject(placedObject);
                }
            }
            else
            {
                Debug.Log("cannot build here");
            }   
        }
        #endregion

        #region HandleDestroy
        //Middle mouse click destroys things
        if (eventData.button == PointerEventData.InputButton.Middle)
        {
            if (placedObject != null)
            {
                placedObject.DestroySelf();
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    GridManager.instance.GetTileAtPosition(gridPosition).ClearPlacedObject();
                }
            }
        }
        #endregion

        //NO ROTATING, PUT ROTATING ON ANOTHER SCRIPT, NOT TILE BASE BUILD
        //dir = PlacedObjectTypeSO.GetNextDir(dir);
    }
    #endregion
}   