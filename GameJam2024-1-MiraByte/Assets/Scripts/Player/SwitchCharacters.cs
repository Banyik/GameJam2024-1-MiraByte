using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    bool isCurrentGuard = false;
    public GameObject guard;
    public GameObject prisoner;

    public void ChangeCharacters()
    {
        if (isCurrentGuard)
        {
            isCurrentGuard = !isCurrentGuard;
            prisoner.SetActive(true);
            guard.SetActive(false);
        }
        else
        {
            isCurrentGuard = !isCurrentGuard;
            prisoner.SetActive(false);
            guard.SetActive(true);
        }
    }
}
