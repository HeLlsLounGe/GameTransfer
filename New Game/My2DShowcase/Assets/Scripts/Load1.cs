using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load1 : MonoBehaviour
{
    public void LoadLv1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lv1");
    }
}
