using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class MetalDetectorGame : MonoBehaviour
{
    public GameObject[] RandomItems;
    public GameObject Key;
    public GameObject Panel;
    public bool findRandomObject;
    public AudioSource beepSource;
    public AudioSource pickupSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
            collision.GetComponent<PlayerBehaviour>().isUsingMetalDetector)
        {
            pickupSource.Play();
            beepSource.Play();
            Panel.SetActive(true);
            if (findRandomObject)
            {
                RandomItems[Random.Range(0, RandomItems.Length)].SetActive(true);
            }
            else
            {
                Key.SetActive(true);
            }
            GameObject.Find("ScriptHandler").GetComponent<UIBehaviour>().DisableObjects();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().canMove = false;
            Invoke(nameof(Delete), 0.5f);
        }
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
