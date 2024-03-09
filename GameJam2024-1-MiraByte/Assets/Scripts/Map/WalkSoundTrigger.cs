using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class WalkSoundTrigger : MonoBehaviour
{
    WalkSoundHandler handler;
    public WalkSoundTypes type;

    private void Start()
    {
        handler = GameObject.Find("ScriptHandler").GetComponent<WalkSoundHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().SetClip(handler.GetClips(type));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehaviour>().SetClip(handler.GetClips(type));
        }
    }
}
