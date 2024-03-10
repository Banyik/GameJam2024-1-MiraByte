using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxLeverHandler : MonoBehaviour
{
    public GameObject[] upLevers;
    public GameObject[] downLevers;
    public bool[] upLeverStates;
    public bool[] downLeverStates;

    public void SetUpLeverState(int lever)
    {
        upLeverStates[lever] = !upLeverStates[lever];
    }
    public void SetDownLeverState(int lever)
    {
        downLeverStates[lever] = !downLeverStates[lever];
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
}
