using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KobraKid : Player
{

    public override void Start()
    {
        base.Start();
        //Kobra Kid's base stats
        SetStat(BaseStatType.Strength, 18);
        SetStat(BaseStatType.Dexterity, 14);
        SetStat(BaseStatType.Constitution, 18);
        SetStat(BaseStatType.Intelligence, 8);
        SetStat(BaseStatType.Charisma, 8);

        killjoy = Killjoys.KobraKid;

        LeftHand = new Weapon(2, 12, BaseStatType.Dexterity, true);


        MaxHealth = 40 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;
        
    }

    public override void Update()
    {
        base.Update();
    }
    
   
}
