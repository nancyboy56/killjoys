using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Item
{
    private bool twoHanded;
    private BaseStatType modifierStat;
    private int minDamage;
    private int maxDamage;

    //i dont want duratablitites

    //could be cool if weapons have levels??
    //lets just get basics right first

    public bool TwoHanded { 
        get { return twoHanded; }
        set { twoHanded = value; } 
    }

    public BaseStatType ModifierStat
    {
        get { return modifierStat; }
        set { modifierStat = value; }
    }

    public int MinDamage
    {
        get { return minDamage; }
        set { if(value>=0) minDamage = value; }
    }

    public int MaxDamage
    {
        get { return maxDamage; }
        set { if (value >= 0) maxDamage = value; }
    }

    public Weapon()
    {
        twoHanded = false;
        modifierStat = BaseStatType.Strength;
        minDamage = 1;
        maxDamage = 4;
    }

    public Weapon(int min, int max, BaseStatType stat, bool twoHanded)
    {
        minDamage = min;
        maxDamage = max;
        modifierStat = stat;
        this.twoHanded = twoHanded;
    }

    // the modifier will happen in the player class bc the player knows ther stats 
    //and the weapon doesnt and doesnt need to
    public int Attack()
    {
        return Random.Range(minDamage, maxDamage);
    }

}
