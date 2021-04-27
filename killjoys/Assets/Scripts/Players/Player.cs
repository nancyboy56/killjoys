using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string killjoyName;
    public List<Pronouns> pronouns;
    public string gender;
    public string sexuality;

    private Dictionary<string, int> stats;

    //
    private int maxStat = 25;
    private int minStat = 6;

    public bool ChangeStat (string stat, int modifer)
    {
        bool added = false; 
        if(stats.ContainsKey(stat) && stats[stat] + modifer < 25 && stat
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
