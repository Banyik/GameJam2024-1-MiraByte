using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTileTextObserver : MonoBehaviour
{
    List<GameObject> tileCheckerScripts = new List<GameObject>();
    GameObject lastAlert;
    bool isAlerted;
    public void Subscribe(GameObject tileScript)
    {
        if (!tileCheckerScripts.Contains(tileScript))
        {
            tileCheckerScripts.Add(tileScript);
        }
    }

    public void UnSubscribe(GameObject tileScript)
    {
        if (tileCheckerScripts.Contains(tileScript))
        {
            tileCheckerScripts.Remove(tileScript);
        }
    }

    public void AlertObserver(GameObject tileScript)
    {
        if(lastAlert != tileScript)
        {
            if (!isAlerted)
            {
                lastAlert = tileScript;
                isAlerted = true;
            }
            else
            {
                if (lastAlert.GetComponent<CheckTile>().IsInvokingText())
                {
                    lastAlert.GetComponent<CheckTile>().CancelDeactivationInvoke();
                }
                lastAlert = tileScript;
            }
        }
    }

    public void DisableAlert()
    {
        isAlerted = false;
    }
}
