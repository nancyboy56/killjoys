using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FunGhoul : Player
{
    public override void Start()
    {
        base.Start();

        //Fun Ghoul's base stats
        SetStat(BaseStatType.Strength, 8);
        SetStat(BaseStatType.Dexterity, 14);
        SetStat(BaseStatType.Constitution, 12);
        SetStat(BaseStatType.Intelligence, 18);
        SetStat(BaseStatType.Charisma, 11);

        killjoy = Killjoys.FunGhoul;

        LeftHand = new Weapon(1, 4, BaseStatType.Dexterity, false);

        MaxHealth = 20 + (int)PlayerStats[BaseStatType.Constitution].Modifier;
        CurrentHealth = MaxHealth;
    }

    public override void Update()
    {
        base.Update();
    }

   
 
   
}
