using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Road : MonoBehaviour
{
    /// <summary>
    /// index 0 for straight, 1 for L shape
    /// </summary>
    ///

    [SerializeField] private Sprite[] roadSprites;
    private SpriteRenderer spriteRenderer;
    private RoadData.RoadShape shape = RoadData.RoadShape.None;
    private bool isRotatable = false;
    private float correctRotation;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (!isRotatable)
            return;
        if(Input.GetMouseButtonUp(0))
        {
            SetRotation(transform.eulerAngles.z + 90);
            CorrectRotationHandler();
        }
    }

    public void Initialize(RoadData.RoadShape roadShape, bool isRotate, float rotation, float correctRot)
    {
        shape = roadShape;
        UpdateRoadSprite();
        isRotatable = isRotate;
        SetRotation(rotation);
        correctRotation = correctRot;
    }

    private void SetRotation(float angle)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }

    private void UpdateRoadSprite()
    {
        switch(shape)
        {
            case RoadData.RoadShape.None:
                spriteRenderer.sprite = roadSprites[0];
                break;
            case RoadData.RoadShape.Horizontal:
                spriteRenderer.sprite = roadSprites[1];
                break;
            case RoadData.RoadShape.LeftDown:
                spriteRenderer.sprite = roadSprites[2];
                break;
        }
    }

    private void CorrectRotationHandler()
    {
        if(transform.eulerAngles.z == correctRotation)
        {
            isRotatable = false;
            RoadManager.Instance.AddACorrectRoad();
        }
    }
}
