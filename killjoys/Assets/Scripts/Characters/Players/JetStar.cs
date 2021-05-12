using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetStar : Player
{

    public override void Start()
    {
        base.Start();
        //Jet Star's base stats
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

    public override void Update()
    {
        base.Update();
    }

   
}
