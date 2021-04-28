using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// there might be an equivent if gold an dislver coins idk yet
//the money system in the game
public class Carbon 
{
    private int carbons;
    private string nameCarbons;

    public Carbon()
    {
        nameCarbons = "Carbon";
        carbons = 0;
    }

    public Carbon(int value)
    {
        nameCarbons = "Carbon";
        carbons = value;
    }

    public string NameCarbons
    {
        get
        {
            return nameCarbons;
        }

        set
        {
            nameCarbons = value;
        }
    }

    public int Carbons
    {
        get 
        {
            return carbons;
        }

        set
        {
            if (value >= 0) carbons = value;
        }
    }

    public bool changeCarbons(int change)
    {
        bool changed = false;
        int newCarbons = change + carbons;
        if(newCarbons >= 0)
        {
            carbons = newCarbons;
        }
        return changed;
    }

}
