using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenMiniGame : MonoBehaviour
{
    bool goLeft = true;
    bool stop = false;
    bool goUp = false;
    public GameObject bone;
    public GameObject Minigame;
    //-190 -58
    public void Try()
    {
        stop = true;
        goUp = false;
    }
    void GoDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
    }
    void GoUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }
    private void Update()
    {
        if (!stop)
        {
            if (transform.localPosition.x > -850 && goLeft)
            {
                GoLeft();
            }
            else if (transform.localPosition.x <= -850 && goLeft)
            {
                goLeft = false;
                GoRight();
            }

            if (transform.localPosition.x < 880 && !goLeft)
            {
                GoRight();
            }
            else if (transform.localPosition.x >= 880 && !goLeft)
            {
                goLeft = true;
                GoLeft();
            }
        }
        else
        {
            if(transform.localPosition.y > 892 && !goUp)
            {
                GoDown();
            }
            else if(transform.localPosition.y <= 892 && !goUp)
            {
                if(transform.localPosition.x >= -192 && transform.localPosition.x <= -58)
                {
                    bone.transform.parent = gameObject.transform;
                }
                goUp = true;
                GoUp();
            }
            if(transform.localPosition.y < 1120 && goUp)
            {
                GoUp();
            }
            else if (transform.localPosition.y >= 1120 && goUp)
            {
                if (transform.localPosition.x >= -192 && transform.localPosition.x <= -58)
                {
                    Minigame.SetActive(false);
                }
                stop = false;
            }
        }
    }

    void GoLeft()
    {
        transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
    }
    void GoRight()
    {
        transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
    }
}
