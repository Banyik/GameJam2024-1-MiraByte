using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class changeTile : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase ogtile;
    public TileBase changedTile;
    public Vector3Int pos;
    public bool set;
    private void OnMouseDown()
    {
        if (!set)
        {
            tilemap.SetTile(pos, changedTile);
            set = true;
        }
        else
        {
            tilemap.SetTile(pos, ogtile);
            set = false;
        }
    }
}
