using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunButton : MonoBehaviour
{
  
    
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        GameObject setup = GameObject.Find("/SetUpCombat");

        if(setup != null)
        {
            GameObject player = setup.GetComponent<SetUpCombat>().order[setup.GetComponent<SetUpCombat>().OrderIndex];
        }

        Debug.Log("You have clicked the run button!");
    }
}


