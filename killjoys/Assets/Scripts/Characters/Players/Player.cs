using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;


public class Player : Character
{
    public Killjoys killjoy;

    
    //saving throws

    // abilities checks

        // each player has a colour


    private float maxWeight;


   
    // i want inventory to be over the whole patry not just on each character

    private Dictionary<WearableType, Wearable> wearing = new Dictionary<WearableType, Wearable>();

    public override void Start()
    {
        base.Start();
        maxWeight = 15 * PlayerStats[BaseStatType.Strength].Modifier;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    public float MaxWeight
    {
        get
        {
            return maxWeight;
        }
        set
        {
            if (value >= 1)
            {
                maxWeight = value;
            }
        }
    }

   


    
}
