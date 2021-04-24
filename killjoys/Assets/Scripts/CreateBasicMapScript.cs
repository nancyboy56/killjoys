using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateBasicMapScript : MonoBehaviour
{
    public float cellInterval = 0.5f;

    public float gridXSize = 10;
    public float gridYSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        // creates grid
        for (float x = -gridXSize; x < gridXSize; x += cellInterval * 2)
        {
            for (float y = -gridYSize; y < gridYSize; y += cellInterval)
            {

                GameObject tile = Instantiate(Resources.Load("Prefabs/Red_Tile", typeof(GameObject))) as GameObject;
                tile.transform.parent = transform;
                tile.name = "Tile" + x + "," + y;
                tile.transform.position = new Vector3(x, y, 0);
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
               // Debug.Log("Making tile " + x + "," + y);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
