using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Player;


public class CameraBehaviour : MonoBehaviour
{
    public float timeToStart;
    public float sleepTime;
    Light2D light2d;
    bool isActive;

    public GameObject gameOverMenu;

    private void Start()
    {
        light2d = gameObject.GetComponent<Light2D>();
        Invoke(nameof(Activate), timeToStart);
    }

    void Activate()
    {
        isActive = !isActive;
        light2d.enabled = isActive;
        Invoke(nameof(Activate), sleepTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "PlayerVisibility" || collision.tag == "Player") && isActive && GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner)
        {
            GameObject.Find("ScriptHandler").GetComponent<UIBehaviour>().DisableObjects();
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerVisibility" || collision.tag == "Player") && isActive && GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner)
        {
            GameObject.Find("ScriptHandler").GetComponent<UIBehaviour>().DisableObjects();
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }

    private void Update()
    {
        if(gameObject.GetComponent<Collider2D>().IsTouching(GameObject.FindWithTag("Player").GetComponent<Collider2D>()) && isActive)
        {
            if(GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner)
            {
                GameObject.Find("ScriptHandler").GetComponent<UIBehaviour>().DisableObjects();
                Time.timeScale = 0f;
                gameOverMenu.SetActive(true);
            }
        }
    }

}
