using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientTrigger : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!source.isPlaying && collision.tag == "Player")
        {
            source.clip = clip;
            source.Play();
            Destroy(this);
        }
    }
}
