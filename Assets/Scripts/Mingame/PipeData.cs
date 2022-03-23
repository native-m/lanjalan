using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeData
{
    public Vector2Int coordinate { private set; get; }
    public bool isLShape { private set; get; }
    public bool isRotatable { private set; get; }
    public float initRotation { private set; get; }
    public float correctRotation { private set; get; }

    public PipeData(Vector2Int index, bool isL, bool canRotate, float rotation, float correctRot)
    {
        coordinate = index;
        isLShape = isL;
        isRotatable = canRotate;
        initRotation = rotation;
        correctRotation = correctRot;
    }
}
