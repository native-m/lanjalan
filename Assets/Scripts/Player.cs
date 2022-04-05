using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody body;
    Vector3 direction = Vector3.zero;

    /*Animator animator;*/

    float moveSpeed = 6.0f;

    void Start() 
    {
        body = GetComponent<Rigidbody>();
        /*animator = GetComponent<Animator>();*/
    }

    void Update() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // animator.SetFloat("MoveX", horizontal);
        // animator.SetFloat("MoveZ", vertical);

        /*if (horizontal != 0)
        {
            animator.SetFloat("MoveX", horizontal);
            if (vertical == 0)
            {
                animator.SetFloat("MoveZ", vertical);
            }
        }

        if (vertical != 0)
        {
            animator.SetFloat("MoveZ", vertical);

            if (horizontal == 0)
            {
                animator.SetFloat("MoveX", horizontal);
            }
        }

        if (horizontal <= -0.5 || horizontal >= 0.5 || vertical <= -0.5 || vertical >= 0.5)
        {
            animator.SetFloat("LastMoveX", horizontal);
            animator.SetFloat("LastMoveZ", vertical);
        }*/
        
        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }

    void FixedUpdate() 
    {
        if(direction.magnitude >= 0.1f)
        {
            body.velocity = new Vector3(direction.x * moveSpeed, body.velocity.y, direction.z * moveSpeed);
            /*animator.SetBool("IsMoving", true);*/
        }
        else
        {
            /*animator.SetBool("IsMoving", false);*/
        }
    }
}
