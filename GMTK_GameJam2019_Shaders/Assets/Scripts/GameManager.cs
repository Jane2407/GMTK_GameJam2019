using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string sceneLevel;

    public void AnotherScene()
    {
        Application.LoadLevel(sceneLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
