using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = warpTo.transform.position;
        }
    }
}
