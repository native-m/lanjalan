using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private GameObject pieceMask;
    private float snapThreshold = 0.5f;
    private Vector3 initPosition;
    private bool isDone = false;
    
    private bool isMoving;
    private Vector3 mousePos;

    private void Start()
    {
        initPosition = transform.position;
    }

    private void Update() 
    {
        if(isMoving)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!isDone)
            {
                isMoving = true;
            }    
        }    
    }

    private void OnMouseUp() 
    {
        if(!isDone)
        {
            isMoving = false;
            mousePos = Vector3.zero;

            if(Mathf.Abs(transform.position.x - pieceMask.transform.position.x) <= snapThreshold &&
            Mathf.Abs(transform.position.y - pieceMask.transform.position.y) <= snapThreshold)
            {
                transform.position = new Vector3(pieceMask.transform.position.x, pieceMask.transform.position.y, transform.position.z);
                isDone = true;
                transform.parent.gameObject.GetComponent<PuzzleManager>().AddScore();
            }
        }
        
    }

    public void ResetPosition()
    {
        transform.position = initPosition;
        isDone = false;
    }
}
