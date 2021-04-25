using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharcaters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject party = Instantiate(Resources.Load("Prefabs/Players/Party_Poison", typeof(GameObject))) as GameObject;
        party.transform.position = new Vector3(0, 0, 0);

        GameManager.Instance.AddPlayer("Party_Poison", party);

        GameObject ghoul = Instantiate(Resources.Load("Prefabs/Players/Fun_Ghoul", typeof(GameObject))) as GameObject;
        ghoul.transform.position = new Vector3(0, -1, 0);

        GameManager.Instance.AddPlayer("Fun_Ghoul", ghoul);

        GameObject jet = Instantiate(Resources.Load("Prefabs/Players/Jet_Star", typeof(GameObject))) as GameObject;
        jet.transform.position = new Vector3(-1, -1, 0);

        GameManager.Instance.AddPlayer("Jet_Star", jet);

        GameObject kobra = Instantiate(Resources.Load("Prefabs/Players/Kobra_Kid", typeof(GameObject))) as GameObject;
        kobra.transform.position = new Vector3(1, -1, 0);

        GameManager.Instance.AddPlayer("Kobra_Kid", kobra);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}