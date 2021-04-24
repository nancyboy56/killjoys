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

    public float cellInterval = 0.5f;
     

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

     void Start()
    {
        for(int i =0; i <= gridYSize*8; i++)
        {
            gridNodes.Add(new List<Node>());
        }
    }


    public void AddTileToGrid(GameObject tile)
    {
        //Debug.Log(tile);
        gridGO.Add(tile);
        float x = tile.transform.position.x;
        float y = tile.transform.position.y;
        

        //ading to grid nodes, with no decimals 
        System.Numerics.Vector2 vec = GetIntVector(x + gridXSize, y + gridYSize);
        Debug.Log(vec);
        gridNodes[(int)vec.Y].Add( new Node(vec, true, 1f));
    }

    public Queue<UnityEngine.Vector2> GetShortestPath(UnityEngine.Vector2 start, UnityEngine.Vector2 end)
    {
        //get vectors in postive and whole numbers
        System.Numerics.Vector2 startIntVec = GetIntVector(start.x+ gridXSize, start.y+gridYSize);
        System.Numerics.Vector2 endIntVec = GetIntVector(end.x + gridXSize, end.y + gridYSize);

        //do a star
        Astar astar = new Astar(gridNodes);
        Stack<Node> pathStack  = astar.FindPath(startIntVec, endIntVec);


        Queue<UnityEngine.Vector2> path = new Queue<UnityEngine.Vector2>();
        List<Node> nodePrint = new List<Node>();
        while (pathStack.Count != 0)
        {
            Node n = pathStack.Pop();
            UnityEngine.Vector2 v = new UnityEngine.Vector2(n.Position.X, n.Position.Y);
            path.Enqueue(v);
            nodePrint.Add(n);

        }

        PrintPath(nodePrint);
        return path;
    }

    private void PrintPath(List<Node> nodes)
    {
        foreach(Node n in nodes)
        {
            Debug.Log("Path: Node: "+ n.Position.X +","+ n.Position.Y);
        }

    }

    public List<GameObject> GetGrid()
    {
        return gridGO;
    }

    private System.Numerics.Vector2 GetIntVector(float x, float y)
    {
        float value = 1 / cellInterval;
        x *= value;
        y *= value*2;
        return new System.Numerics.Vector2(x, y);
    }
    

    public void AddPlayer(string name, GameObject go)
    {
        players.Add(name, go);
    }

    public Dictionary<string, GameObject> GetPlayers()
    {
        return players;
    }


}
