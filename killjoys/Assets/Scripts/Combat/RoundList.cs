using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoundList : MonoBehaviour
{
    public Text text;
    SetUpCombat setup;
    Dictionary<Killjoys, int> healths = new Dictionary<Killjoys, int>();
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        setup = GameObject.Find("/SetUpCombat").GetComponent<SetUpCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        //
          
        Dictionary<Killjoys, GameObject> players = GameManager.Instance.GetPlayers();


        

    }
}
