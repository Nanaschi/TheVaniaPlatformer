using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //Configurations
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
    [SerializeField] float runSpeed = 1f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbingSpeed = 2f;

    bool isAlive = true;

    //Cached component reference
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D feetCollider;
    float myGravityScaleAtStart;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        myGravityScaleAtStart = myRigidBody.gravityScale;
    }

    void Update()
    {

        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Jump();
        ClimbingTheLadder();
        Die();
    }
    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) || feetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myRigidBody.velocity = deathKick;
            myAnimator.SetTrigger("Dying");
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
           
        }
    }


    private void Jump()
    {

        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
        bool playerVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > 0.3;
        myAnimator.SetBool("Jumping", playerVerticalSpeed);
    }
    private void Run()
    {

        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
       
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > 0.5;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
     
        
    }



    private void ClimbingTheLadder()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {

            myAnimator.SetBool("Climbing", false);

            myRigidBody.gravityScale = myGravityScaleAtStart;
            return;

        }

        myRigidBody.gravityScale = 0;
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbingSpeed);
        myRigidBody.velocity = climbVelocity;
        bool playerVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", true);
        var currentPos = transform.position.y;

    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
        
    }
   
}
