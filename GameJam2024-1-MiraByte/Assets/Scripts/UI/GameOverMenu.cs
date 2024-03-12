using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public void Retry() 
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(2);
    }
    public void BackToMainMenu() 
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void QuitApp() 
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
