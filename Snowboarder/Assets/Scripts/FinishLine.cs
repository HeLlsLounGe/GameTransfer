using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float WinDelay = 1f;
    [SerializeField] ParticleSystem WinEffect;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            WinEffect.Play();
            Debug.Log("YOU WIN");
            Invoke("ReloadScene", WinDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
