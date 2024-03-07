using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class CameraBehaviour : MonoBehaviour
{
    public float timeToStart;
    public float sleepTime;
    Light2D light2d;
    bool isActive;

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
        if((collision.tag == "PlayerVisibility" || collision.tag == "Player") && isActive)
        {
            Debug.Log("game over");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerVisibility" || collision.tag == "Player") && isActive)
        {
            Debug.Log("game over");
        }
    }

}