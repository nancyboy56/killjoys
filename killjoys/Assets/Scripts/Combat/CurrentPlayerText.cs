using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerText : MonoBehaviour
{
    private Text text;
    SetUpCombat setup;
    private string playerName= "";
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        setup = GameObject.Find("/SetUpCombat").GetComponent<SetUpCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerName.Equals(setup.order[setup.OrderIndex].name))
        {
            text.text = setup.order[setup.OrderIndex].name;
            playerName = setup.order[setup.OrderIndex].name;
        }
       
    }
}
