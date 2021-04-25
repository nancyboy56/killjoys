using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class TileData1 : MonoBehaviour
{
    

    private bool walkable;

    public string tileType;

    public void SetWalkable(bool isTrue)
    {
        walkable = isTrue;
    }

    public bool GetWalkable()
    {
        return walkable;
    }

    public void SetTileType(string type)
    {
        tileType = type;
    }

    public string GetTileType()
    {
        return tileType;
    }

}
