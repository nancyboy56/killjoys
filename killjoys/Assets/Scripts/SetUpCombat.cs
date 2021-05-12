using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCombat : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    private List<GameObject> order = new List<GameObject>();

    public int orderIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.state = GameStates.Combat;

        if(GameManager.Instance.GetPlayers().Count == 0)
        {
            GameObject party = Instantiate(Resources.Load("Prefabs/Players/Party_Poison")) as GameObject;
            party.transform.position = new Vector3(0.5f, -0.75f, 0);

            GameManager.Instance.AddPlayer(Killjoys.PartyPoison, party);

            GameObject ghoul = Instantiate(Resources.Load("Prefabs/Players/Fun_Ghoul")) as GameObject;
            ghoul.transform.position = new Vector3(2.5f, 0.25f, 0);

            GameManager.Instance.AddPlayer(Killjoys.FunGhoul, ghoul);

            GameObject jet = Instantiate(Resources.Load("Prefabs/Players/Jet_Star")) as GameObject;
            jet.transform.position = new Vector3(1.5f, -0.25f, 0);

            GameManager.Instance.AddPlayer(Killjoys.JetStar, jet);

            GameObject kobra = Instantiate(Resources.Load("Prefabs/Players/Kobra_Kid")) as GameObject;
            kobra.transform.position = new Vector3(3.5f, 0.75f, 0);

            GameManager.Instance.AddPlayer(Killjoys.KobraKid, kobra);
        }
        else
        {
            
        }


        //for testing
        GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemies/DracBasic")) as GameObject;
        enemy.transform.position = new Vector3(0.5f,0.75f, 0);

        enemies.Add(enemy);

        //get compent my script my fucnction

     
        
       // enemies.Add(enemy);
        // GameManager.Instance.enemies.Add(enemy);

        


    }

    

    // Update is called once per frame
    void Update()
    {

        // sets up initaive (the order) for turn based combat
        if(order.Count == 0)
        {
            // add enmenies
            foreach (GameObject go in enemies)
            {
                order.Add(go);
                if (go.GetComponent<Character>() != null)
                {
                    go.GetComponent<Character>().Initative();
                    Debug.Log("Intivative " + go.name + ", " + go.GetComponent<Character>().initiative);
                }
            }

            // add players
            foreach( GameObject go in GameManager.Instance.GetPlayers().Values)
            {
                order.Add(go);
                if (go.GetComponent<Character>() != null)
                {
                    
                    go.GetComponent<Character>().Initative();
                    Debug.Log("Intivative " + go.name + ", " + go.GetComponent<Character>().initiative);
                }
            }

            order.Sort((a, b) => (b.GetComponent<Character>().initiative).CompareTo(
                a.GetComponent<Character>().initiative));

            foreach(GameObject go in order){
                Debug.Log(go.name);
            }
        }
 
    }
}
