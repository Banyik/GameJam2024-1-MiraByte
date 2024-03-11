using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxLeverHandler : MonoBehaviour
{
    public GameObject[] upLevers;
    public GameObject[] downLevers;
    public bool[] upLeverStates;
    public bool[] downLeverStates;
    public GameObject[] activeObjects;
    public void SetUpLeverState(int lever)
    {
        upLeverStates[lever] = !upLeverStates[lever];
        CheckIfDisarmed();
    }
    public void SetDownLeverState(int lever)
    {
        downLeverStates[lever] = !downLeverStates[lever];
        CheckIfDisarmed();
    }

    public void GetLeverStates()
    {
        for (int i = 0; i < upLeverStates.Length; i++)
        {
            upLevers[i].SetActive(upLeverStates[i]);
        }
        for (int i = 0; i < downLeverStates.Length; i++)
        {
            downLevers[i].SetActive(downLeverStates[i]);
        }
    }

    public void DeactivateAll()
    {
        foreach (var item in upLevers)
        {
            item.SetActive(false);
        }
        foreach (var item in downLevers)
        {
            item.SetActive(false);
        }
    }

    public bool IsDisarmedState()
    {
        return upLevers[0] && !upLevers[1] && upLevers[2] && upLevers[3] && !upLevers[4];
    }

    public void CheckIfDisarmed()
    {
        if (IsDisarmedState())
        {
            foreach (var item in activeObjects)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (var item in activeObjects)
            {
                item.SetActive(true);
            }
        }
    }
}
