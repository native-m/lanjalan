using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody body;
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    private Animator animator;

    float moveSpeed = 0.5f;


    void Start() 
    {
        body = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update() 
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(moveDirection.sqrMagnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
            moveDirection *= moveSpeed;
            controller.Move(moveDirection * Time.deltaTime);

            animator.SetFloat("MoveSpeed", 1);
        }
        else
        {
            animator.SetFloat("MoveSpeed", 0);
        }
    }
}
