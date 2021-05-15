using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurnButton : MonoBehaviour
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
        setup.OrderIndex += 1;

        Debug.Log("You have clicked the next turn button!");
    }
}
