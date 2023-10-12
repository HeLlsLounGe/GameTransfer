using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float EnemySpeed = 5f;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = new Vector2(EnemySpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            EnemySpeed = -EnemySpeed;
            FlipEnemyDir();
        }
    }

    void FlipEnemyDir()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(rb2d.velocity.x)), 1f);
    }
}
