using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    private float weight = 0;
    private string itemName;
    private string description;

    // which killjoys can use the item
    private Killjoys[] useable;

    // differnet might things for a higher price sell high, buy low
    private int value;

    // minimum stats to use
    private Dictionary<BaseStatType, int> minStats;


}
