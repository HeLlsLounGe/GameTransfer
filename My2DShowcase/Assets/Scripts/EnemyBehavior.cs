using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public float ChaseDistance = 5f;
    [SerializeField] public float MoveSpeed = 5f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Atk")
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Atk")
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Vector3 PlayerPosition = player.transform.position;
        Vector3 MoveDirection = PlayerPosition - transform.position;
        if (MoveDirection.magnitude <= ChaseDistance)
        {
            MoveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = MoveDirection * MoveSpeed * Time.deltaTime * 60;
        }
    }
}
