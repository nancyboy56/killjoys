using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    private Dictionary<string, GameObject> players =  new Dictionary<string, GameObject>();
    private List<GameObject> grid = new List<GameObject>();

    public void addTileToGrid(GameObject tile)
    {
        grid.Add(tile);
    }

    public List<GameObject> getGrid()
    {
        return grid;
    }

    public void addPlayer(string name, GameObject go)
    {
        players.Add(name, go);
    }

    public Dictionary<string, GameObject> getPlayers()
    {
        return players;
    }


}
