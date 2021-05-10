using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[System.Serializable]
public class Player
{

    public string killjoyName;
    public List<Pronouns> pronouns = new List<Pronouns>();
    public string gender;
    public string sexuality;
    public int age;
    public Killjoys killjoy;

    private Dictionary<BaseStatType, Stats> stats =  new Dictionary<BaseStatType, Stats>();

    //saving throws

    // abilities checks

        // each player has a colour


    private float maxWeight;
    private int maxHealth;
    private int minHealth;
    private int currentHealth;
    private Weapon leftHand;
    private Weapon rightHand;
    private float amourClass;

    // i want inventory to be over the whole patry not just on each character

    private Dictionary<WearableType, Wearable> wearing = new Dictionary<WearableType, Wearable>();

    public Player(string name)
    {
       
        killjoyName = name;
        SetDefault();
       
    }

    public void SetDefault()
    {
        Pronouns p = new Pronouns();
        pronouns.Add(p);
      
        gender = "unlabeled";
        sexuality = "unlabeled";
        age = 25;

        // default stats all 10
        stats.Add(BaseStatType.Strength, new Stats(BaseStatType.Strength, 10));
        stats.Add(BaseStatType.Dexterity, new Stats(BaseStatType.Dexterity, 10));
        stats.Add(BaseStatType.Constitution, new Stats(BaseStatType.Constitution, 10));
        stats.Add(BaseStatType.Intelligence, new Stats(BaseStatType.Intelligence, 10));
        stats.Add(BaseStatType.Charisma, new Stats(BaseStatType.Charisma, 10));

        maxHealth = 10;
        minHealth = 0;

        leftHand = new Weapon();
        rightHand = new Weapon();
        currentHealth = maxHealth;

        maxWeight = 15 * stats[BaseStatType.Strength].Modifier;

        amourClass = 10 + stats[BaseStatType.Dexterity].Modifier;
    }

    // this will change as not all players can use all the weapons
    public Weapon LeftHand
    {
        get
        {
            return leftHand;
        }
        set
        {
            leftHand = value;
        }
    }

    public Weapon RightHand
    {
        get
        {
            return rightHand;
        }
        set
        {
            rightHand = value;
        }
    }






    // change as in a base stat + change, add or minus from the stat
    public void ChangeStat( BaseStatType stat, int change)
    {
        if (stats.ContainsKey(stat))
        {
            stats[stat].ChangeStat(change);
        }
    }

    public void SetStat(BaseStatType stat, int num)
    {
        if (stats.ContainsKey(stat))
        {
            stats[stat].BaseStat = num;
        }
    }

    public Dictionary<BaseStatType, Stats> PlayerStats
    {
        get
        {
            return stats;
        }
    }




    public List<Pronouns> Pronouns
    {
        get
        {
            return pronouns;
        }

        set
        {
            pronouns = value;
        }
    }

    public void AddPronouns( Pronouns p)
    {
        if (!pronouns.Contains(p))
        {
            pronouns.Add(p);
        }
    }

    public void RemovePronouns(Pronouns p)
    {
        if (pronouns.Contains(p))
        {
            pronouns.Remove(p);
        }
    }


    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            if( value >= 18)
            {
                age = value;
            }
        }
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

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            if(value> minHealth && value > 0)
            {
                maxHealth = value;
            }
        }
    }



    public int MinHealth
    {
        get
        {
            return minHealth;
        }
        set
        {
            if(value< maxHealth)
            {
                minHealth = value;
            }
        }
    }

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            if(value < minHealth)
            {
                currentHealth = minHealth;
            } else if( value >= minHealth && value <= maxHealth)
            {
                currentHealth = value;
            } else if (value >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    public int ChangeHealth( int change)
    {
        int newHealth = currentHealth + change;
        if (newHealth < minHealth)
        {
            currentHealth = minHealth;
        }
        else if (newHealth >= minHealth && newHealth <= maxHealth)
        {
            currentHealth = newHealth;
        }
        else if (newHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        return currentHealth;
    }


    
}
