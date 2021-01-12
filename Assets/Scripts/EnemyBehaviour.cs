
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] bool flipCheck;
    [SerializeField] float moveSpeed = 30f;
    Rigidbody2D myRigidBody;
    
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementLogic();
        
    }

    public void MovementLogic()
    {
        if (FacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed * Time.deltaTime, 0f);
        } else
            myRigidBody.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0f);


    }
    bool FacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enemy Exited!");
        transform.localScale = new Vector2(-(Math.Sign(myRigidBody.velocity.x)), 1f);
    }
}
