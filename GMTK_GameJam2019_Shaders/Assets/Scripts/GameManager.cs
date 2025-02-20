﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string Level01;
    public string MainMenu;

    bool isInMenu;
    bool hasImpulse;
    
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject uiPanel;
    [SerializeField] public GameObject settingPanel;
    [SerializeField] public GameObject creditsPanel;
    [SerializeField] public GameObject quitPanel;
    [SerializeField] public GameObject pointPanel;


    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioSource audioSourcePauseMenu;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isInMenu)
        {
            isInMenu = true;
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isInMenu)
        {
            UnPauseGame();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(Level01);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        uiPanel.SetActive(false);
        pausePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        audioSource.Pause();
        audioSourcePauseMenu.Play();
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(false);
        quitPanel.SetActive(false);

        if (hasImpulse)
        {
            uiPanel.SetActive(true);
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isInMenu = false;

        audioSource.Play();
        audioSourcePauseMenu.Pause();
    }

    public void ShowImpulseIcon()
    {
        hasImpulse = true;
        uiPanel.SetActive(true);
    }

    public void CloseImpulseIcon()
    {
        hasImpulse = false;
        uiPanel.SetActive(false);
    }

    public void GotPoint()
    {
        pointPanel.SetActive(true);
        Invoke("ClosePointPanel", 2);
    }

    public void ClosePointPanel()
    {
        pointPanel.SetActive(false);
    }
}
