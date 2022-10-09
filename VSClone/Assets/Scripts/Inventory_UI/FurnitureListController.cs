using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureListController : ButtonListControl
{
    [SerializeField] private MouseManager mouseManager;

    //public BaseBuildTile bbt;

    protected override void TestingPlacingItem(BaseItems itemType)
    {
        RefreshScrollBarMenu();

        //bbt.placeObjectTypeSO = itemType.placedObjectTypeSO;
        InventoryManager.instance.AddItem(itemType, 3);


        mouseManager.gameObject.SetActive(true);
        mouseManager.GetComponent<SpriteRenderer>().sprite = itemType.ItemIcon;
    }

    protected override void SetList()
    {
        ScrollBarList = InventoryManager.instance.CheckItem;  //For furniture, the list is based on Inventory, supplier will be like Receattear
    }
}
