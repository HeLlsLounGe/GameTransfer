using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load2 : MonoBehaviour
{
    public void LoadLv2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lv2");
    }
}
