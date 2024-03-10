using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject basePauseMenu, pauseButton;
    public void Pause() 
    {
        Time.timeScale = 0f;
        basePauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Resume() 
    {
        Time.timeScale = 1f;
        basePauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void BackToMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
