using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    
    private SetUpCombat setup;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        setup = GameObject.Find("/SetUpCombat").GetComponent<SetUpCombat>();
        button.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {

        // GameManager.Instance.enemies[0].Damage();
        GameObject player = setup.order[setup.OrderIndex];
        int health = player.GetComponent<Player>().CurrentHealth;
        
        Debug.Log("You have clicked the attack button!");
    }

  

}
