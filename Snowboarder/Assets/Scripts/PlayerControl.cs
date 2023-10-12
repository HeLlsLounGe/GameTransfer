using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] ParticleSystem Snow;
    [SerializeField] float TorqueAmount = 1f;
    [SerializeField] float Speed = 1f;
    [SerializeField] float Brakes = 1f;
    int maxParts;

    Rigidbody2D rb2d;

    void OnCollisionStay2D(Collision2D other)
    {
        Snow.maxParticles = maxParts;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddForce(transform.right * Speed * Time.deltaTime * 60);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.AddForce(-transform.right * Brakes * Time.deltaTime * 60);
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        Snow.maxParticles = 0;
    }

    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
        maxParts = Snow.main.maxParticles;
        Snow.maxParticles = 0;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-TorqueAmount * Time.deltaTime * 60);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(TorqueAmount * Time.deltaTime * 60);
        }
    }
}
