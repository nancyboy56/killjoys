using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{

    private float weight = 0;
    private string itemName;
    private string description;

    // which killjoys can use the item
    private Killjoys[] useable;

    // differnet might things for a higher price sell high, buy low
    private Carbon value;

    // minimum stats to use
    // only add stats that are 
    private Dictionary<BaseStatType, int> minStats;

    public Item()
    {
        value = new Carbon();

        // this is a hardcoded number but idk if i should get it from somewhere
        useable = new Killjoys[] { Killjoys.PartyPoison, Killjoys.KobraKid,
            Killjoys.JetStar, Killjoys.FunGhoul };

    }

    public Item(string name, string description, int newValue, int newWeight)
    {
        value = new Carbon(newValue);
        Weight = newWeight;
        itemName = name;
        this.description = description;
        useable = new Killjoys[] { Killjoys.PartyPoison, Killjoys.KobraKid,
            Killjoys.JetStar, Killjoys.FunGhoul };
    }

    public Item(string name, string description, int newValue, int newWeight, Killjoys [] killjoys)
    {
        value = new Carbon(newValue);
        Weight = newWeight;
        itemName = name;
        this.description = description;
        useable = killjoys;
    }

    public Item(string name, string description, int newValue, int newWeight, 
        Dictionary<BaseStatType, int> minStats)
    {
        value = new Carbon(newValue);
        Weight = newWeight;
        itemName = name;
        this.description = description;
        useable = new Killjoys[] { Killjoys.PartyPoison, Killjoys.KobraKid,
            Killjoys.JetStar, Killjoys.FunGhoul };
        this.minStats = minStats;
    }

    public Item(string name, string description, int newValue, int newWeight, Killjoys[] killjoys,
        Dictionary<BaseStatType, int> minStats)
    {
        value = new Carbon(newValue);
        Weight = newWeight;
        itemName = name;
        this.description = description;
        useable = killjoys;
        this.minStats = minStats;
    }


    public Killjoys[] Useable
    {
        get
        {
            return useable;
        }
    }

    public string ItemName { 
        get
        { 
            return itemName; 
        }
        set { 
            itemName = value;
        }
    }

    public Carbon Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value =value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }



    public float Weight
    {
        get
        {
            return weight;
        }
        set 
        {
            if (value >= 0) weight = value;
        } 
    }



}
