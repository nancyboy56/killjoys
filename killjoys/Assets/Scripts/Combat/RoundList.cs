using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoundList : MonoBehaviour
{
    public Text text;
    SetUpCombat setup;
    bool isSetUp = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        setup = GameObject.Find("/SetUpCombat").GetComponent<SetUpCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(setup.order.Count != 0)
        {
            if (!isSetUp)
            {
                string round = "Round: ";
                foreach (GameObject character in setup.order)
                {
                    Debug.Log("yes wow");
                    round += character.name + ", ";
                    Debug.Log(round);
                }

                text.text = round;
                isSetUp = true;
            }
        }
        
        //
        


        

    }
}
