using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChoiceManager : MonoBehaviour
{

    public InMemoryVariableStorage variableStorage;
    

    // Start is called before the first frame update
    void Start()
    {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();
        (Dictionary<string, float>, Dictionary<string, string>, Dictionary<string, bool>) v 
            = variableStorage.GetAllVariables();
       

    }

    public string GetStateString(string stateName)
    {
        string state;
        variableStorage.TryGetValue<string>(stateName, out state);
        return state;
    }

    public float GetStateFloat(string stateName)
    {
        float state;
        variableStorage.TryGetValue<float>(stateName, out state);
        return state;
    }

    public bool GetStateBool(string stateName)
    {
        bool state;
        variableStorage.TryGetValue<bool>(stateName, out state);
        print(stateName);
       // Debug.Log("does read screen exist: "+ variableStorage.TryGetValue<bool>("readScreen", out s));
        return state;
    }

    public void updateState(string stateName, bool state)
    {
       variableStorage.SetValue(stateName, state);
        
    }

    public void updateState(string stateName, string state)
    {
        variableStorage.SetValue(stateName, state);
    }

    public void updateState(string stateName, float state)
    {
        
        variableStorage.SetValue(stateName, state);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
