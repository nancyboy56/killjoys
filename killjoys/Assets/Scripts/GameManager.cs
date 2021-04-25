using AStar;
using AStarSharp;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    public int speed = 10;

    private GameObject tm;

    private Vector2 mapSize;

    Pathfinding pf;

    public Dictionary<string, WorldTile> worldTiles = new Dictionary<string, WorldTile>();

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
        //gridNodes = new short[80, 80];
        tm = GameObject.Find("Ground");
        Tilemap map = tm.GetComponent<Tilemap>();

        mapSize = new UnityEngine.Vector2(map.size.x, map.size.y);
        Debug.Log("map size" + mapSize);

        createWorldTile();
    }


    public void AddTileToGrid(GameObject tile)
    {
        /*//Debug.Log(tile);
        gridGO.Add(tile);
        float x = tile.transform.position.x;
        float y = tile.transform.position.y;
        

        //ading to grid nodes, with no decimals 
        System.Numerics.Vector2 vec = GetIntVector(x + gridXSize, y + gridYSize);
        //Debug.Log(vec);
       // gridNodes[(int) vec.Y, (int) vec.X] = 1;*/
    }


    private void createWorldTile()
    {
        Tilemap map = tm.GetComponent<Tilemap>();

        TileBase[] tileArray = map.GetTilesBlock( new BoundsInt(-100, -100, -2, 1000, 1000, 10) );
        

        for(int y =-10; y < 50; y++)
        {
            for(int x=-10; x < 50; x++)
            
                if(map.HasTile(new Vector3Int(x, y, 0)))
                {
                    worldTiles.Add(x+","+y, new WorldTile(true, x, y));

                }
            }
        }
    

    public Vector3 CellToPosition(int x, int y)
    {
        Tilemap map = tm.GetComponent<Tilemap>();
        Vector3 pos = map.CellToWorld(new Vector3Int(x, y, 0));
        return new Vector3(pos.x, pos.y + 0.5f, pos.z);
    }

    public Vector3Int PositionToCell(Vector2 pos)
    {
        Tilemap map = tm.GetComponent<Tilemap>();
        Vector3 newPos = new Vector2(pos.x, pos.y - 0.5f);
        return map.WorldToCell(newPos);

    }

    public Queue<Vector2> GetShortestPath(Vector2 start, Vector2 end)
    {
        Vector3Int newStart = PositionToCell(start);
        Vector3Int newEnd = PositionToCell(end);

        List<WorldTile> pathTiles = pf.FindPathFromWorldPos(worldTiles[newStart.x + "," + newStart.y],
            worldTiles[newEnd.x + "," + newEnd.y]);

        Queue<Vector2> path = new Queue<Vector2>();

        foreach(WorldTile tile in pathTiles)
        {
            path.Enqueue(CellToPosition(tile.gridX, tile.gridY));
        }
        return path;
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
