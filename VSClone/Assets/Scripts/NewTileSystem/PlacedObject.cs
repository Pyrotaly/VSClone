using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    private PlacedObjectTypeSO placedObjectTypeSO;
    private PlacedObjectTypeSO.Dir dir;

    public SpriteRenderer sR;
    public Sprite[] spriteList;

    public static PlacedObject Create(Vector3 worldPosition, PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO)
    {
        Transform placedObjectTransform = Instantiate(placedObjectTypeSO.prefab, worldPosition,   //need to instantiate prefab based on degree
            Quaternion.Euler(0, 0, placedObjectTypeSO.GetRotationAngle(dir)));  

        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();

        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        placedObject.dir = dir;

        return placedObject;
    }

    //Sets sprite to correct rotation
    private void Start()
    {
        ////Too lazy to do smart way
        //if (dir == PlacedObjectTypeSO.Dir.Down)
        //{
        //    sR.sprite = spriteList[0];
        //}
        //else if (dir == PlacedObjectTypeSO.Dir.Left)
        //{
        //    sR.sprite = spriteList[1];
        //}
        //else if (dir == PlacedObjectTypeSO.Dir.Up)
        //{
        //    sR.sprite = spriteList[2];
        //}
        //else //Right
        //{
        //    sR.sprite = spriteList[3];
        //}
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
