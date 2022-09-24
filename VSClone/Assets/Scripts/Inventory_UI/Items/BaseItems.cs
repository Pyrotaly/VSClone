using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItems : ScriptableObject
{
    public Sprite ItemIcon;
    public string ItemName;
    public int ItemId;
    public float ItemPrice;
    public float ItemRobChance;
}

//Supplier selling item
