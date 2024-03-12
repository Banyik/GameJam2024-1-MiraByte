using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAsGuard : MonoBehaviour
{
    public changeTile TileChanger;
    bool isCalled = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isCalled)
        {
            TileChanger.ChangeTile();
            isCalled = true;
        }
    }
}
