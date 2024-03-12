using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject basePauseMenu, pauseButton, resumeButton, helpMenu, pauseMenu, optionsMenu;
    public void Start()
    {
        Time.timeScale = 1f;
    }
    public void Pause() 
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        basePauseMenu.SetActive(true);
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
        helpMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
    public void Resume() 
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        basePauseMenu.SetActive(false);      
        resumeButton.SetActive(false);
        helpMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void BackToMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
    public void ShowHelpMenu()
    {
        helpMenu.SetActive(true);
        basePauseMenu.SetActive(false);
        pauseButton.SetActive(false);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void ShowOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        basePauseMenu.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(false);
        helpMenu.SetActive(false);
    }
}
