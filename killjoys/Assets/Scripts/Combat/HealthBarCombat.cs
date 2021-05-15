using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCombat : MonoBehaviour
{
    public Text text;
    SetUpCombat setup;
    private int previousHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        setup = GameObject.Find("/SetUpCombat").GetComponent<SetUpCombat>();


    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = setup.order[setup.OrderIndex];
        int health = player.GetComponent<Player>().CurrentHealth;
        if(health != previousHealth)
        {
            text.text = "Health: " + health;
            previousHealth = health;
        }
    }
}
