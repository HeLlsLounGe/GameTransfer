using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wipeout : MonoBehaviour
{
    [SerializeField] float LoseDelay = 0.5f;
    [SerializeField] ParticleSystem LoseEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Kill")
        {
            LoseEffect.Play();
            Debug.Log("Hall Of Meat For You");
            Invoke("ReloadScene", LoseDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
