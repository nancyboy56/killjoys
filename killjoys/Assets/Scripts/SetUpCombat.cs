using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCombat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.state = GameStates.Combat;

        if(GameManager.Instance.GetPlayers().Count == 0)
        {
            GameObject party1 = Instantiate(Resources.Load("Prefabs/Players/Party_Poison", typeof(GameObject))) as GameObject;
            party1.transform.position = new Vector3(0.5f, -0.75f, 0);

            GameManager.Instance.AddPlayer(Killjoys.PartyPoison, party1);

            GameObject ghoul = Instantiate(Resources.Load("Prefabs/Players/Fun_Ghoul", typeof(GameObject))) as GameObject;
            ghoul.transform.position = new Vector3(2.5f, 0.25f, 0);

            GameManager.Instance.AddPlayer(Killjoys.FunGhoul, ghoul);

            GameObject jet = Instantiate(Resources.Load("Prefabs/Players/Jet_Star", typeof(GameObject))) as GameObject;
            jet.transform.position = new Vector3(1.5f, -0.25f, 0);

            GameManager.Instance.AddPlayer(Killjoys.JetStar, jet);

            GameObject kobra = Instantiate(Resources.Load("Prefabs/Players/Kobra_Kid", typeof(GameObject))) as GameObject;
            kobra.transform.position = new Vector3(3.5f, 0.75f, 0);

            GameManager.Instance.AddPlayer(Killjoys.KobraKid, kobra);
        }
        else
        {
            
        }


        //for testing
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemies/DracBasic", typeof(GameObject))) as GameObject;
        enemy.transform.position = new Vector3(0.5f,0.75f, 0);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
