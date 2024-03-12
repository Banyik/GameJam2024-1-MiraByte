using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    
    public void DisableObjects()
    {
        foreach (var item in objects)
        {
            item.SetActive(false);
        }
    }
    public void EnableObjects()
    {
        foreach (var item in objects)
        {
            item.SetActive(true);
        }
    }
}
