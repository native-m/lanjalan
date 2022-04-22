using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string defaultCharaModelPath;
    private GameObject currentCharaModel = null;

    private Rigidbody body;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private Animator animator = null;

    private float moveSpeed = 0.5f;
    
    [SerializeField] private float gravity = -2f;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 fallVelocity = new Vector3(0f, 0.5f, 0f);
    private bool isGrounded;
    private float groundDistance = 0.02f;

    private void Awake() 
    {
        body = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        LoadCharaModelHandler();
    }

    private void Update() 
    {
        Move();
    }

    private void LoadCharaModelHandler()
    {
        string tempPath = PlayerPrefs.GetString("ModelPath");
        if (tempPath == "")
        {
            tempPath = defaultCharaModelPath;
        }
        SetCharacterModel(tempPath);
    }

    public void SetCharacterModel(string modelPath)
    {
        if (modelPath == null)
        {
            Destroy(animator);
            Destroy(currentCharaModel);
        }
        else
        {
            print(modelPath);
            GameObject model = Resources.Load<GameObject>(modelPath);
            if(model == null)
            {
                print("Mode Not Found");
            }
            else
            {
                currentCharaModel = Instantiate(model, transform);
                animator = currentCharaModel.GetComponent<Animator>();
                PlayerPrefs.SetString("ModelPath", modelPath);
            }
        }
    }

    private void Move()
    {
        // Gravity
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer);
        if(isGrounded && fallVelocity.y < 0)
        {
            fallVelocity.y = 0.5f;
        }
        else
        {
            float deltaTime = Time.deltaTime;
            fallVelocity.y += (gravity * deltaTime * deltaTime);
            controller.Move(fallVelocity);
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(moveDirection.sqrMagnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
            moveDirection *= moveSpeed;
            controller.Move(moveDirection * Time.deltaTime);

            SetAnimatorVar("MoveSpeed", 1f);
        }
        else
        {
            SetAnimatorVar("MoveSpeed", 0f);
        }
    }

    private void SetAnimatorVar(string varName, float value)
    {
        if(animator != null)
        {
            animator.SetFloat(varName, value);
        }
    }
}
