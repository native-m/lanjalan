using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    private float panSpeed = 2f;
    private float panBorderThickness = 40f;
    private Vector3 panDirection = Vector3.zero;
    private Rect screenRect;

    private float minCamX = -0.5f;
    private float maxCamX = 2.5f;

    private float minCamY = 2f;
    private float maxCamY = 3.5f;

    private float minCamZ = -5f;
    private float maxCamZ = 0f;

    private void Awake()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
    }

    private void Update()
    {
        FreeMoveHandler();
    }

    private void FreeMoveHandler()
    {
        
        MouseDirectionHandler();
        MoveOnMouseDirection();
    }

    private void MouseDirectionHandler()
    {
        if (!screenRect.Contains(Input.mousePosition))
        {
            return;
        }

        Vector3 tempDirection = Vector3.zero;
        //Move Up and Down
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            tempDirection += Vector3.forward;
        }
        else if (Input.mousePosition.y <= panBorderThickness)
        {
            tempDirection += Vector3.back;
        }

        //Move Left and Right
        if (Input.mousePosition.x <= panBorderThickness)
        {
            tempDirection += Vector3.left;
        }
        else if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            tempDirection += Vector3.right;
        }

        //Move Forward and Backward
        tempDirection.y = -50 * Input.GetAxis("Mouse ScrollWheel");

        panDirection = tempDirection;
    }

    private void MoveOnMouseDirection()
    {
        if (panDirection != Vector3.zero)
        {
            transform.Translate(panDirection * panSpeed * Time.deltaTime, Space.World);
            Vector3 tempPos = transform.position;
            tempPos.x = Mathf.Clamp(transform.position.x, minCamX, maxCamX);
            tempPos.y = Mathf.Clamp(transform.position.y, minCamY, maxCamY);
            tempPos.z = Mathf.Clamp(transform.position.z, minCamZ, maxCamZ);

            transform.position = tempPos;
        }
    }
}
