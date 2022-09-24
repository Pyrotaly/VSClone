using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ButtonListControl : MonoBehaviour
{
    [SerializeField] protected Transform newButtonTemplate;

    protected List<BaseItems> ScrollBarList;         //I am duplicating list when I just want to refer to list but less keystrokes!!!
    protected Action testAction;

    protected List<Transform> CreatedButtons = new List<Transform>();

    protected void Start()
    {
        RefreshScrollBarMenu();
    }

    protected void RefreshScrollBarMenu()
    {
        //Remove current buttons so when new buttons are made, previous buttons won't linger
        if (CreatedButtons.Count != 0)
        {
            foreach (Transform t in CreatedButtons)
            {
                Destroy(t.gameObject);
            }
            CreatedButtons.Clear();
        }

        SetList();

        for (int i = 0; i < ScrollBarList.Count; i++) //There should be the same length for all data types
        {
            CreateItemButton(ScrollBarList[i], ScrollBarList[i].ItemIcon, ScrollBarList[i].ItemName, ScrollBarList[i].ItemPrice, i);
        }
    }

    //This is for only one menu, creates list of buttons for items
    protected void CreateItemButton(BaseItems item, Sprite itemSprite, string itemName, float itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(newButtonTemplate);
        shopItemTransform.SetParent(newButtonTemplate.transform.parent, false);
        shopItemTransform.gameObject.SetActive(true);
        CreatedButtons.Add(shopItemTransform);

        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.GetComponent<Button>().onClick.AddListener(delegate { TestingPlacingItem(item); });
    }

    protected abstract void TestingPlacingItem(BaseItems itemType);

    protected abstract void SetList();
}

