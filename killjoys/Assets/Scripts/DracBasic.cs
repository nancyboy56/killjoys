using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DracBasic : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(this);
        }
        
    }

    public void Damage(int dam)
    {
        currentHealth -= dam;
            if (currentHealth <= 0)
        {

            Destroy(this);
        }
    }
}
