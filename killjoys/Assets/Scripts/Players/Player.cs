using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string killjoyName;
    public List<Pronouns> pronouns;
    public string gender;
    public string sexuality;

    private Dictionary<BaseStatType, Stats> stats;

    //saving throws

    // abilities checks


    private int maxWeight;
    private int maxHealth;
    private int currentHealth;
    private Weapon leftHand;
    private Weapon rightHand;
    
    // i want inventory to be over the whole patry not just on each character





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
