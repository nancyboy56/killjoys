using AStarSharp;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    private List<GameObject> gridGO = new List<GameObject>();

    private List<List<Node>> gridNodes = new List<List<Node>>();

    public int gridXSize = 10;

    public int gridYSize = 10;

    public int speed = 10;
     

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    

    public void AddTileToGrid(GameObject tile)
    {
        gridGO.Add(tile);
        float x = tile.transform.position.x;
        float y = tile.transform.position.y;
        gridNodes[(int)y+gridYSize].Add( new Node(new System.Numerics.Vector2(x+gridXSize,y+gridYSize), true, 1f));
    }

    public Queue<UnityEngine.Vector2> GetShortestPath(UnityEngine.Vector2 start, UnityEngine.Vector2 end)
    {
        Astar astar = new Astar(gridNodes);
        Stack<Node> pathStack  = astar.FindPath(new System.Numerics.Vector2(start.x+gridXSize, start.y+ gridYSize), 
            new System.Numerics.Vector2(end.x+ gridYSize, end.y + gridYSize));
        Queue<UnityEngine.Vector2> path = new Queue<UnityEngine.Vector2>();
        List<Node> nodePrint = new List<Node>();
        while (pathStack.Count != 0)
        {
            Node n = pathStack.Pop();
            UnityEngine.Vector2 v = new UnityEngine.Vector2(n.Position.X, n.Position.Y);
            path.Enqueue(v);
            nodePrint.Add(n);

        }

        printPath(nodePrint);
        return path;
    }

    private void printPath(List<Node> nodes)
    {
        foreach(Node n in nodes)
        {
            Debug.Log("Path: Node: "+ n.Position.X +","+ n.Position.Y);
        }

    }

    public List<GameObject> getGrid()
    {
        return gridGO;
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
