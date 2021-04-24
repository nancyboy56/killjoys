using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateBasicMapScript : MonoBehaviour
{
    public float cellInterval = 0.5f;

    private float gridXSize = 10;
    private float gridYSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        gridXSize = GameManager.Instance.gridXSize;
        gridYSize = GameManager.Instance.gridYSize;

        // creates grid
        for (float x = -gridXSize; x < gridXSize; x += cellInterval * 2)
        {
            for (float y = -gridYSize; y < gridYSize; y += cellInterval)
            {

                GameObject tile = Instantiate(Resources.Load("Prefabs/Red_Tile", typeof(GameObject))) as GameObject;
                tile.transform.parent = transform;
                tile.name = "Tile" + x + "," + y;
                tile.transform.position = new Vector3(x, y, 0);
                GameManager.Instance.AddTileToGrid(tile);
                //  Debug.Log("Making tile " + x + "," + y);

            }
        }

        for (float x = -gridXSize+ cellInterval; x < gridXSize; x += cellInterval*2)
        {
            for (float y = -gridYSize + cellInterval/2; y < gridYSize; y += cellInterval)
            {

                GameObject tile = Instantiate(Resources.Load("Prefabs/Red_Tile", typeof(GameObject))) as GameObject;
                tile.transform.parent = transform;
                tile.name = "Tile" + x + "," + y;
                tile.transform.position = new Vector3(x, y, 0);

                GameManager.Instance.AddTileToGrid(tile);
               // Debug.Log("Making tile " + x + "," + y);

            }
        }

        swapnPlayers();


    }

    private void swapnPlayers()
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
