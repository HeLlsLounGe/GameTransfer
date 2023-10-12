using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;
    [SerializeField] float PlayerSpeed = 10f;
    [SerializeField] float WinTimer = 150f;
    Animator MyAnimator;
    Vector2 moveInput;
    Rigidbody2D myRigidBody;

    float timer = 0f;
    public Text TimerTxt;

    bool IsAlive = true;
    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(IsAlive == false)
        {
            DeathScreen.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        Run();

        timer += Time.deltaTime;
        if (timer > WinTimer && IsAlive)
        {
            timer = 0;
            SceneManager.LoadScene("YouWin");
        }
    }
    
    void OnFire(InputValue value)
    {
        if (IsAlive)
        {
            if (moveInput.y >= 1f)
            {
                MyAnimator.SetTrigger("UpA");
            }
            else if (moveInput.y <= -1f)
            {
                MyAnimator.SetTrigger("DownA");
            }

            if (moveInput.x >= 1f)
            {
                MyAnimator.SetTrigger("RightA");
            }
            else if (moveInput.x <= -1f)
            {
                MyAnimator.SetTrigger("LeftA");
            }

            if (moveInput.x == 0 && moveInput.y == 0)
            {
                MyAnimator.SetTrigger("UpA");
            }
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        if (IsAlive)
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * PlayerSpeed, moveInput.y * PlayerSpeed);
            myRigidBody.velocity = playerVelocity;

            bool PlayerHZMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
            bool PlayerVCMoving = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            if (PlayerHZMoving)
            {
                MyAnimator.SetFloat("x", 1);
            }
            else if (!PlayerHZMoving)
            {
                MyAnimator.SetFloat("x", 0);
            }

            if (PlayerVCMoving)
            {
                MyAnimator.SetFloat("y", 1);
            }
            else if (!PlayerVCMoving)
            {
                MyAnimator.SetFloat("y", 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IsAlive = false;
            Debug.Log("owie");
        } 
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
