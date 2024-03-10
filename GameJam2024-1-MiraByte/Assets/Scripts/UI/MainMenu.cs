using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject castMenu, optionsMenu, preMenu;

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void ShowOptions() 
    {
        optionsMenu.SetActive(true);
        preMenu.SetActive(false);
    }

    public void ShowCast() 
    {
        castMenu.SetActive(true);
        preMenu.SetActive(false);
    }
    public void QuitApp() 
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ShowPreMenu() 
    {
        preMenu.SetActive(true);
        castMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
}
