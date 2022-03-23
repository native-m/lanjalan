using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    /// <summary>
    /// index 0 for straight, 1 for L shape
    /// </summary>
    [SerializeField] private Sprite[] pipeSprites;
    private SpriteRenderer spriteRenderer;
    private bool isLShape = false;
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
        }
    }

    public void Initialize(bool isL, bool isRotate, float rotation, float correctRot)
    {
        isLShape = isL;
        spriteRenderer.sprite = pipeSprites[Convert.ToInt32(isLShape)];
        isRotatable = isRotate;
        SetRotation(rotation);
        correctRotation = correctRot;
    }

    private void SetRotation(float angle)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }
}
