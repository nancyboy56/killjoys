using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetStar : Player
{
    public JetStar(string name = "Jet Star") : base(name)
    {
        setStats();
        killjoy = Killjoys.JetStar;

        LeftHand = new Weapon(1, 8, BaseStatType.Dexterity, false);
        

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
