using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    public float moveSpeed = 6.0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start() 
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
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
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // float forwardAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, forwardAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * moveSpeed * Time.deltaTime);
        }
    }
}
