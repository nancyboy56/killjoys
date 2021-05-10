using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KobraKid : Player
{
    public KobraKid(string name = "Kobra Kid") : base(name)
    {
        setStats();
        killjoy = Killjoys.KobraKid;

        LeftHand = new Weapon(2, 12, BaseStatType.Dexterity, true);
        

        MaxHealth = 35 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;

    }


    //Party Posions's base stats
    private void setStats()
    {
        SetStat(BaseStatType.Strength, 14);
        SetStat(BaseStatType.Dexterity, 18);
        SetStat(BaseStatType.Constitution, 12);
        SetStat(BaseStatType.Intelligence, 14);
        SetStat(BaseStatType.Charisma, 8);

    }
}
