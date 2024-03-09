using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class EnableWalking : MonoBehaviour
{
    public void EnableMoving()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().canMove = true;
    }
}
