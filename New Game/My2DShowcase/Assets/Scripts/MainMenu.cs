using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadLv1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lv1S");
    }

    public void LoadLv2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lv2S");
    }
}
