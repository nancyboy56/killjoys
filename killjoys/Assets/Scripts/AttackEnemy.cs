using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackEnemy : MonoBehaviour
{
    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
       // GameManager.Instance.enemies[0].Damage();
        Debug.Log("You have clicked the attack button!");
    }


}
