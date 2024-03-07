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
            Debug.Log($"Added {tileScript.name}");
        }
    }

    public void UnSubscribe(GameObject tileScript)
    {
        if (tileCheckerScripts.Contains(tileScript))
        {
            tileCheckerScripts.Remove(tileScript);
            Debug.Log($"Removed {tileScript.name}");
        }
    }

    public void AlertObserver(GameObject tileScript)
    {
        if(lastAlert != tileScript)
        {
            Debug.Log($"Alert from {tileScript.name}");
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
                    Debug.Log($"Cancelling Invoke to {lastAlert.name}");
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
