using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetStar : Player
{
   


    //Jet Star's base stats
    private void setStats()
    {
        SetStat(BaseStatType.Strength, 14);
        SetStat(BaseStatType.Dexterity, 18);
        SetStat(BaseStatType.Constitution, 12);
        SetStat(BaseStatType.Intelligence, 14);
        SetStat(BaseStatType.Charisma, 8);
        killjoy = Killjoys.JetStar;

        LeftHand = new Weapon(1, 8, BaseStatType.Dexterity, false);


        MaxHealth = 35 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;

    }
}
