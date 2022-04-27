using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoadData
{
    public enum RoadShape
    {
        None,
        Horizontal,
        LeftDown,
    }

    public Vector2Int coordinate { private set; get; }
    public RoadShape roadShape { private set; get; }
    public bool isRotatable { private set; get; }
    public float initRotation { private set; get; }
    public float correctRotation { private set; get; }

    public RoadData(Vector2Int index, RoadShape shape, bool canRotate, float rotation, float correctRot)
    {
        coordinate = index;
        roadShape = shape;
        isRotatable = canRotate;
        initRotation = rotation;
        correctRotation = correctRot;
    }
}
