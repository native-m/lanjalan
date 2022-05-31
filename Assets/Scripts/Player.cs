using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] characterModels;
    private GameObject currentCharaModel = null;
    private int currentModelIndex = -1;

    private DialogCameraManager dialogCamManager = null;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private Animator animator = null;

    private float moveSpeed = 0.5f;
    
    [SerializeField] private float gravity = -2f;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 fallVelocity = new Vector3(0f, 0.5f, 0f);
    private bool isGrounded;
    private float groundDistance = 0.01f;

    private Vector3 centerPoint = new Vector3(0f, 0.1f, 0f);
    private float interactRadius = 0.15f;
    private bool isInteracting = false;
    private bool canInteract = true;

    private void Awake() 
    {
        controller = GetComponent<CharacterController>();
        LoadCharaModelHandler();
    }

    private void Start()
    {
        if(Chapter1Manager.Instance != null)
        {
            transform.position = Chapter1Manager.Instance.PlayerInteractPosition;
        }

        if (dialogCamManager == null)
        {
            GameObject dialogCamOperator = GameObject.Find("DialogCamera");

            if (dialogCamOperator != null)
            {
                dialogCamManager = dialogCamOperator.GetComponent<DialogCameraManager>();
            }
        }
    }

    private void Update() 
    {
        Move();

        if (Chapter1Manager.Instance != null)
        {
            if(Chapter1Manager.Instance.IsCutscenePlaying)
            {
                return;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void LoadCharaModelHandler()
    {
        int tempIndex = PlayerPrefs.GetInt("ModelIndex");
        SetCharacterModel(tempIndex);
    }

    public void SetCharacterModel(int index)
    {
        if (animator != null)
        {
            Destroy(animator);
        }
        if (currentCharaModel != null)
        {
            Destroy(currentCharaModel);
        }

        GameObject model = characterModels[index];
        if (model == null)
        {
            print("Mode Not Found");
        }
        else
        {
            currentCharaModel = Instantiate(model, transform);
            currentModelIndex = index;
            animator = currentCharaModel.GetComponent<Animator>();
            PlayerPrefs.SetInt("ModelIndex", index);
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
            fallVelocity = AdjustVelocityToSlope(fallVelocity);
            controller.Move(fallVelocity);
        }

        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (isInteracting)
        {
            moveDirection = Vector3.zero;
        }
        else
        {
            moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        }
        
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

    private Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        var ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.0001f))
        {
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedVelocity = slopeRotation * velocity;

            if (adjustedVelocity.y < 0)
            {
                return adjustedVelocity;
            }
        }

        return velocity;
    }

    private void SetAnimatorVar(string varName, float value)
    {
        if(animator != null)
        {
            animator.SetFloat(varName, value);
        }
    }

    private void Interact()
    {
        if (isInteracting)
        {
            return;
        }

        if (!canInteract)
        {
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position + centerPoint, interactRadius, 1<<LayerMask.NameToLayer("NPC"));
        if(colliders.Length > 0)
        {
            NPC npc = colliders[0].GetComponent<NPC>();
            isInteracting = true;
            canInteract = false;
            dialogCamManager.ActivateCamera("DialogCam0");
            Chapter1Manager.Instance.StartInteract(npc.DialogueStart, npc.DialogueEnd, npc.IsDialogueMainStory);
        }
    }

    public void PostInteractHandler()
    {
        isInteracting = false;
        StartCoroutine(ReenableInteract());
    }

    IEnumerator ReenableInteract()
    {
        yield return new WaitForEndOfFrame();
        canInteract = true;
    }

    //Debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + centerPoint, interactRadius);
    }
}
