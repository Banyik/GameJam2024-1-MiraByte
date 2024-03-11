using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ListMenu : MonoBehaviour
{
    public GameObject listMenu, listButton, pauseButton;
    public void ShowList() 
    {
        Time.timeScale = 0f;
        listMenu.SetActive(true);
        listButton.SetActive(false);
        pauseButton.SetActive(false);
    }
    public void Resume() 
    {
        Time.timeScale = 1f;
        listMenu.SetActive(false);
        listButton.SetActive(true);
        pauseButton.SetActive(true);
    }
}
