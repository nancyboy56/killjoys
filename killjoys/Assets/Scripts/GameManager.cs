using AStar;
using AStarSharp;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    private List<GameObject> gridGO = new List<GameObject>();

    private short[,] gridNodes;

    public int gridXSize = 10;

    public int gridYSize = 10;

    public int speed = 10;

    public float cellInterval = 0.5f;

    private WorldGrid wg;

    private Tilemap tm;

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
        gridNodes = new short[80, 80];
        tm = GameObject.Find("Ground");

    }


    public void AddTileToGrid(GameObject tile)
    {
        //Debug.Log(tile);
        gridGO.Add(tile);
        float x = tile.transform.position.x;
        float y = tile.transform.position.y;
        

        //ading to grid nodes, with no decimals 
        System.Numerics.Vector2 vec = GetIntVector(x + gridXSize, y + gridYSize);
        //Debug.Log(vec);
        gridNodes[(int) vec.Y, (int) vec.X] = 1;
    }

    public Queue<UnityEngine.Vector2> GetShortestPath(UnityEngine.Vector2 start, UnityEngine.Vector2 end)
    {
        if (wg == null)
        {
            wg = new WorldGrid(gridNodes);
        }
        
        //get vectors in postive and whole numbers
        System.Numerics.Vector2 startIntVec = GetIntVector(start.x+ gridXSize, start.y+gridYSize);
        System.Numerics.Vector2 endIntVec = GetIntVector(end.x + gridXSize, end.y + gridYSize);

        Queue<UnityEngine.Vector2> path = new Queue<UnityEngine.Vector2>();
        
        PathFinder pf = new PathFinder(wg);
        Point[] pathPoints = pf.FindPath(new System.Drawing.Point((int)startIntVec.X, (int)startIntVec.Y),
            new Point((int)endIntVec.X, (int)endIntVec.Y));

        float value = cellInterval * 4;
        foreach (Point p  in pathPoints)
        {
            path.Enqueue(new UnityEngine.Vector2(p.X/value -gridXSize, p.Y/(value*2) -gridYSize));
            
        }

        //PrintPath(pathPoints);


        //do a star
        //Astar astar = new Astar(gridNodes);
        /*Stack<Node> pathStack  = astar.FindPath(startIntVec, endIntVec);


        Queue<UnityEngine.Vector2> path = new Queue<UnityEngine.Vector2>();
        List<Node> nodePrint = new List<Node>();
        while (pathStack.Count != 0)
        {
            Node n = pathStack.Pop();
            UnityEngine.Vector2 v = new UnityEngine.Vector2(n.Position.X, n.Position.Y);
            path.Enqueue(v);
            nodePrint.Add(n);

        }

        PrintPath(nodePrint);*/
        return path;
    }

   

    private void PrintPath(Point[] nodes)
    {
        float value = cellInterval * 4;
        foreach (Point n in nodes)
        {
            float x = n.X / value - gridXSize;
            float y = (n.Y / (value * 2)) - gridYSize;
            Debug.Log("Path Node: "+ x + ","+ y);
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
