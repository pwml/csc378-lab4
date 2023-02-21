using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlToMain : MonoBehaviour
{
    public string mainMenuScene;

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
