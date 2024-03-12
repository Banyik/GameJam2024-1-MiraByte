using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockerIncrement : MonoBehaviour
{
    int current = 0;
    public void Increment()
    {
        if(current == 9)
        {
            current = 0;
        }
        else
        {
            current++;
        }
        gameObject.GetComponentInChildren<TMP_Text>().text = current.ToString();
    }
}
