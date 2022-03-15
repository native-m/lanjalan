using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTile : MonoBehaviour
{
    private int tileId;
    private bool isInAnswer;
    private Vector3 initialPosition = Vector3.zero;

    private void Start()
    {
        isInAnswer = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!isInAnswer)
            {
                WordManager.Instance.MoveToAnswerArea(this);
            }
            else
            {
                WordManager.Instance.MovetoLetterArea(this);
            }
        }
    }

    public void SetInitialPositiion(Vector3 initPos)
    {
        initialPosition = initPos;
        transform.localPosition = initialPosition;
    }

    public Vector3 GetInitialPositiion()
    {
        return initialPosition;
    }

    public void SetTileId(int id)
    {
        tileId = id;
    }

    public int GetTileId()
    {
        return tileId;
    }

    public void SetIsInAnswer(bool value)
    {
        isInAnswer = value;
    }
}
