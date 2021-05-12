using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPosion : Player
{
  


    //Party Posions's base stats
    private void setStats()
    {
        SetStat(BaseStatType.Strength, 10);
        SetStat(BaseStatType.Dexterity, 16);
        SetStat(BaseStatType.Constitution, 13);
        SetStat(BaseStatType.Intelligence, 8);
        SetStat(BaseStatType.Charisma, 18);

        killjoy = Killjoys.PartyPoison;

        LeftHand = new Weapon(1, 6, BaseStatType.Dexterity, false);
        RightHand = new Weapon(1, 6, BaseStatType.Dexterity, false);

        MaxHealth = 30 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;

    }
}
