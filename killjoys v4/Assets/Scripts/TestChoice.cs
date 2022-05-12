using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChoice : MonoBehaviour
{
    public ChoiceManager choiceManager;
    public GameObject choicePrefab;
    // Start is called before the first frame update
    void Start()
    {
        choicePrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test Choice");
        print("read screna : "+ choiceManager.GetStateBool("$readScreen"));
        // i dont want to check this every frame only when varaibles update??
        //i mean it might not take up that much space bc its a small game
        // but it seems likea bad code
        if (choiceManager.GetStateBool("$readScreen")){
            Debug.Log("show cube");
            choicePrefab.SetActive(true);
        }
    }

    private void UpdateVaraible()
    {
        if (choiceManager != null)
        {
            //choiceManager.updateState
        }
    }
}
