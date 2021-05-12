using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KobraKid : Player
{
    //Kobra Kid's base stats
    private void setStats()
    {
        SetStat(BaseStatType.Strength, 18);
        SetStat(BaseStatType.Dexterity, 14);
        SetStat(BaseStatType.Constitution, 18);
        SetStat(BaseStatType.Intelligence, 8);
        SetStat(BaseStatType.Charisma, 8);

        killjoy = Killjoys.KobraKid;

        LeftHand = new Weapon(2, 12, BaseStatType.Dexterity, true);


        MaxHealth = 35 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;

    }
}
