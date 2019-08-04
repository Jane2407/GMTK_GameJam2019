using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string Level01;

    public void NextLevel()
    {
        Application.LoadLevel(Level01);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
