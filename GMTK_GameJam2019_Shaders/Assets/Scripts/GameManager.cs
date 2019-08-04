using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string Level01;

    public GameObject pausePanel;
    public GameObject inGamePanel;

    public void NextLevel()
    {
        Application.LoadLevel(Level01);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        inGamePanel.SetActive(false);
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        inGamePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        //blnPaused = false;
    }

}
