using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    private Dictionary<Killjoys, int> healths = new Dictionary<Killjoys, int>();
    private SetUpCombat setup;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        setup = GameObject.Find("/SetUpCombat").GetComponent<SetUpCombat>();
        text = GetComponent<Text>();
        healths.Add(Killjoys.FunGhoul, 0);
        healths.Add(Killjoys.PartyPoison, 0);
        healths.Add(Killjoys.JetStar, 0);
        healths.Add(Killjoys.KobraKid, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool hasChange = false;
        Dictionary<Killjoys, GameObject> players = GameManager.Instance.GetPlayers();


        foreach (GameObject player in players.Values)
        {
            Player playerInfo = player.GetComponent<Player>();
            if(playerInfo.CurrentHealth != healths[playerInfo.killjoy]) {
                healths[playerInfo.killjoy] = playerInfo.CurrentHealth;
                hasChange = true;
            }
        }
        if (hasChange)
        {
            string playerlist = "";
            foreach(GameObject player in players.Values)
            {
                Player playerInfo = player.GetComponent<Player>();
                if (playerInfo.killjoy.Equals(Killjoys.PartyPoison))
                {
                    playerlist += "Party Poison \n";
                } 
                else if (playerInfo.killjoy.Equals(Killjoys.FunGhoul))
                {
                    playerlist += "Fun Ghoul \n";
                } 
                else if (playerInfo.killjoy.Equals(Killjoys.JetStar))
                {
                    playerlist += "Jet Star \n";
                } 
                else if (playerInfo.killjoy.Equals(Killjoys.KobraKid))
                {
                    playerlist += "Kobra Kid \n";
                }

                playerlist += "Health: " + playerInfo.CurrentHealth + "\n\n";
            }
            text.text = playerlist;
            
        }
    }
}
