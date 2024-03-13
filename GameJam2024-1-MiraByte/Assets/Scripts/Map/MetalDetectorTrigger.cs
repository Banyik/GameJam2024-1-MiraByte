using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class MetalDetectorTrigger : MonoBehaviour
{
    public AudioSource beepSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
            collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {
            beepSource.loop = true;

            if (!beepSource.isPlaying)
            {
                beepSource.Play();
            }
        }
        else if(collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
            !collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {
            if (beepSource.isPlaying)
            {
                beepSource.Stop();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
            collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {
            if (!beepSource.isPlaying)
            {
                beepSource.Play();
            }
        }
        else if (collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
            !collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {

            if (beepSource.isPlaying)
            {
                beepSource.Stop();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
           collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {
            beepSource.loop = false;
            if (beepSource.isPlaying)
            {
                beepSource.Stop();
            }
        }
        else if (collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
           !collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {

            if (beepSource.isPlaying)
            {
                beepSource.Stop();
            }
        }
    }
}
