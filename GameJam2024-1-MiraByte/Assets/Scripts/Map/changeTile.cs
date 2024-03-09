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

    public bool playSound;
    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;

    public void ChangeTile()
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
            if (playSound)
            {
                source.clip = clip1;
                source.Play();
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
            if (playSound)
            {
                source.clip = clip2;
                source.Play();
            }
        }
    }
}
