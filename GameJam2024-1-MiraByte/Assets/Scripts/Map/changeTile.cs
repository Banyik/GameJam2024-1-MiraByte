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
    public bool changeObjectActivity;

    public List<GameObject> objects = new List<GameObject>();
    private void OnMouseDown()
    {
        if (!set)
        {
            tilemap.SetTile(pos, changedTile);
            set = true;
            if (changeObjectActivity)
            {
                foreach (var obj in objects)
                {
                    obj.SetActive(false);
                }
            }
        }
        else
        {
            tilemap.SetTile(pos, ogtile);
            set = false;
            if (changeObjectActivity)
            {
                foreach (var obj in objects)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}
