using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

public class TriggerScene : MonoBehaviour
{
    public int scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
