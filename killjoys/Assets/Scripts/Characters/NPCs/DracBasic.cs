using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracBasic : NPC
{
    


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void TakeDamage(int dam)
    {
        CurrentHealth -= dam;
        if (CurrentHealth <= 0)
        {
            Destroy(this);
        }
    }
}
