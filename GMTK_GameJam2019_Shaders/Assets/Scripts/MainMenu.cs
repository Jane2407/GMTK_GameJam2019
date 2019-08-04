using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string Level1;

    public void LoadGame()
    {
        SceneManager.LoadScene(Level1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
