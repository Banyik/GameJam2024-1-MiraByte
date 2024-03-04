using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpPlayer : MonoBehaviour
{
    public bool enabled = true;

    public GameObject player;

    public Vector3 warpTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = warpTo;
    }
}
