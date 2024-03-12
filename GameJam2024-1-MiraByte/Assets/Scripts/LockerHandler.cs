using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LockerHandler : MonoBehaviour
{
    public string neededNum;
    public Button[] buttons;
    public GameObject lockerLock;
    public GameObject lockerInside;

    public AudioSource openSoundSource;

    public void CheckIfCorrect()
    {
        string temp = "";
        foreach (var button in buttons)
        {
            temp += button.GetComponentInChildren<TMP_Text>().text;
        }
        if(temp == neededNum)
        {
            openSoundSource.Play();
            lockerLock.SetActive(false);
            lockerInside.SetActive(true);
        }
    }

}
