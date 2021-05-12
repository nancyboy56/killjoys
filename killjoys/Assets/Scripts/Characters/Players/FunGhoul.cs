using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FunGhoul : Player
{



    public FunGhoul(string name = "Fun Ghoul") 
    {
        setStats();
        killjoy = Killjoys.FunGhoul;

        LeftHand = new Weapon(1, 4, BaseStatType.Dexterity, false);

        MaxHealth = 20 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;

    }


    //Fun Ghoul's base stats
    private void setStats()
    {
        SetStat(BaseStatType.Strength, 8);
        SetStat(BaseStatType.Dexterity, 14);
        SetStat(BaseStatType.Constitution, 12);
        SetStat(BaseStatType.Intelligence, 18);
        SetStat(BaseStatType.Charisma, 11);

        

    }
   
}
