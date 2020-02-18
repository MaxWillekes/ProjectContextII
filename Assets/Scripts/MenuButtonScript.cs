using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void LoadLevel()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
