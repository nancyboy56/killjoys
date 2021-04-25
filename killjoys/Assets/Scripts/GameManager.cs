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

    private Pathfinding pf = new Pathfinding();

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
        
        tm = GameObject.Find("Ground");
        Tilemap map = tm.GetComponent<Tilemap>();

        mapSize = new Vector2(map.size.x, map.size.y);
        //Debug.Log("map size" + mapSize);

        createWorldTile();
    }




    private void createWorldTile()
    {
        Tilemap map = tm.GetComponent<Tilemap>();

        Tilemap wallMap = GameObject.Find("Walls").GetComponent<Tilemap>();

        for (int y = -30; y < 50; y++)
        {
            for (int x = -30; x < 50; x++)
            {
                if (map.HasTile(new Vector3Int(x, y, 0)))
                {
                    worldTiles.Add(x + "," + y, new WorldTile(true, x, y));
                   // spawnCirclesTiles(x, y);
                   
                }
            }
        }

        for (int a = -30; a < 50; a++)
        {
           // Debug.Log("wow2");
            for (int b = -30; b < 50; b++)
            {
                //Debug.Log("wow1");
                //spawnCirclesTiles(b, a);
                if (wallMap.HasTile(new Vector3Int(b, a, 0)))
                {
                    //Debug.Log("wow");
                    if(worldTiles.ContainsKey(b + "," + a)){
                        worldTiles[b + "," + a].walkable = false;
                        //spawnCirclesTiles(b, a);
                    }
                    else
                    {
                        //Debug.Log("doesnt exist" + b + ","+a);
                        worldTiles.Add(b + "," + a, new WorldTile(false, b, a));
                        spawnCirclesTiles(b, a);
                    }


                }
            }
        }

       

        foreach (WorldTile tile in worldTiles.Values)
        {
            WorldTile wt = worldTiles[tile.gridX + "," + tile.gridY];
            if (wt.walkable)
            {
                wt.myNeighbours = getNeighbours(tile.gridX, tile.gridY);
                foreach (WorldTile neighbours in wt.myNeighbours)
                {
                    if (!neighbours.walkable)
                        wt.specialCost = 10;
                }
            }
            else
            {
                wt.myNeighbours = new List<WorldTile>();
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
        Vector3 newPos = new Vector2(pos.x, pos.y -0.5f);
        return map.WorldToCell(newPos);

    }

    public Queue<Vector2> GetShortestPath(Vector2 start, Vector2 end)
    {
        Vector3Int newStart = PositionToCell(start);
        Vector3Int newEnd = PositionToCell(end);
        //Debug.Log("start cell:" + worldTiles[newStart.x + "," + newStart.y].gridX + "," + worldTiles[newStart.x + "," + newStart.y].gridY);
        //Debug.Log("end cell:" + worldTiles[newEnd.x + "," + newEnd.y].gridX +","+ worldTiles[newEnd.x + "," + newEnd.y].gridY);

        List<WorldTile> pathTiles = pf.FindPathFromWorldPos(worldTiles[newStart.x + "," + newStart.y],
            worldTiles[newEnd.x + "," + newEnd.y]);
        Queue<Vector2> path = new Queue<Vector2>();

        foreach(WorldTile tile in pathTiles)
        {
            path.Enqueue(CellToPosition(tile.gridX, tile.gridY));
            //Debug.Log("PAth:" + tile.gridX+","+tile.gridY);
        }
        return path;
    }

    private void spawnCirclesTiles(int x, int y)
    {

        GameObject party = Instantiate(Resources.Load("Prefabs/circle", typeof(GameObject))) as GameObject;
        party.transform.position = CellToPosition(x, y);
        party.name = "circle " + x + "," + y;

    }





    public void AddPlayer(string name, GameObject go)
    {
        players.Add(name, go);
    }

    public Dictionary<string, GameObject> GetPlayers()
    {
        return players;
    }


    public List<WorldTile> getNeighbours(int x, int y)
    {
        List<WorldTile> myNeighbours = new List<WorldTile>();

        //Need to get all 8 directions
        // // / / // / /
        //1. Up = x, y + 1;
        //2. up-right = x + 1, y + 1;
        //3. right = x + 1, y;
        //4. down right = x + 1, y - 1
        //5. down = x, y - 1;
        //6. down left = x - 1, y - 1;
        //7. left = x - 1;
        //8. left up = x - 1, y + 1;

        if (worldTiles.ContainsKey(x+","+ (y + 1)) && worldTiles[x + "," + (y + 1)].walkable)
        {
            WorldTile wt1 = worldTiles[x+","+ (y + 1)];
            myNeighbours.Add(wt1);
        }

        if (worldTiles.ContainsKey((x + 1)+","+ (y + 1)) && worldTiles[(x + 1) + "," + (y + 1)].walkable)
        {
            WorldTile wt2 = worldTiles[(x + 1)+","+(y + 1)];
            myNeighbours.Add(wt2);
        }

        if (worldTiles.ContainsKey((x + 1)+","+ y) && worldTiles[(x + 1) + "," + y].walkable)
        {
            WorldTile wt3 = worldTiles[(x + 1)+","+ y];
            myNeighbours.Add(wt3);
        }

        if (worldTiles.ContainsKey((x + 1)+","+ (y - 1)) && worldTiles[(x + 1) + "," + (y - 1)].walkable)
        {
            WorldTile wt4 = worldTiles[(x + 1)+","+ (y - 1)];
            myNeighbours.Add(wt4);
        }

        if (worldTiles.ContainsKey(x+","+(y - 1)) && worldTiles[x + "," + (y - 1)].walkable)
        {
            WorldTile wt5 = worldTiles[x+"," +(y - 1) ];
            myNeighbours.Add(wt5);
        }


        if (worldTiles.ContainsKey((x - 1)+","+ (y - 1)) && worldTiles[(x - 1) + "," + (y - 1)].walkable)
        {
            WorldTile wt6 = worldTiles[(x - 1)+","+(y - 1)];
            myNeighbours.Add(wt6);
        }

        if (worldTiles.ContainsKey((x - 1)+","+ y) && worldTiles[(x - 1) + "," + y].walkable)
        {
            WorldTile wt7 = worldTiles[(x - 1)+","+ y];
            myNeighbours.Add(wt7);
        }

        if (worldTiles.ContainsKey((x - 1)+","+ (y + 1)) && worldTiles[(x - 1) + "," + (y + 1)].walkable)
        {
            WorldTile wt8 = worldTiles[(x - 1)+","+ (y + 1)];
            myNeighbours.Add(wt8);
        }
        
        return myNeighbours;
    }

}
