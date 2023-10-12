using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float PlayerSpeed = 5f;
    [SerializeField] float ClimbSpeed = 5f;
    [SerializeField] Vector2 DeathKick = new Vector2(10f, 10f);
    [SerializeField] ParticleSystem LoseEffect;
    float GravityAtStart;
    bool IsAlive = true;

    Vector2 MoveInput;

    Rigidbody2D myRigidBody;
    Animator MyAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFootCollider;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFootCollider = GetComponent<BoxCollider2D>();
        GravityAtStart = myRigidBody.gravityScale;
    }

    
    void Update()
    {
        if (!IsAlive) {return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!IsAlive) {return;}
        MoveInput = value.Get<Vector2>();
        Debug.Log(MoveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(MoveInput.x * PlayerSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool PlayerHZMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        MyAnimator.SetBool("IsRunning", PlayerHZMoving);
    }

    void OnJump(InputValue value)
    {
        if (!IsAlive) {return;}
        if (!myFootCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}

        if(value.isPressed)
        {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void FlipSprite()
    {
        bool PlayerHZMoving = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (PlayerHZMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
    
    void ClimbLadder()
    {
        if (!myFootCollider.IsTouchingLayers(LayerMask.GetMask("Ladders"))) 
        {
            myRigidBody.gravityScale = GravityAtStart;
            MyAnimator.SetBool("IsClimbing", false);
            return; 
        }

        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, MoveInput.y *ClimbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;

        bool PlayerVCMoving = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        MyAnimator.SetBool("IsClimbing", PlayerVCMoving);
    }

    void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards", "Water")))
        {
            IsAlive = false;
            MyAnimator.SetTrigger("Dying");
            LoseEffect.Play();
            myRigidBody.velocity = DeathKick;
        }
    }
}
