using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float TurnSpeed = 0.1f;
    [SerializeField] float MoveSpeed = 0.01f;
    [SerializeField] float SlowSpeed = 15f;
    [SerializeField] float FastSpeed = 25f;
    private Vector3 Respawn;
    bool IsAlive = true;
    private void Start()
    {
        Respawn = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        MoveSpeed = SlowSpeed;
        IsAlive = false;
        if (IsAlive == false)
        {
            transform.position = Respawn;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("YEEE HAW");
            MoveSpeed = FastSpeed;
        }
    }

    void Update()
    {
        float SteerAmount = Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime;
        float DriveControl = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -SteerAmount);
        transform.Translate(0, DriveControl, 0);
    }
}
