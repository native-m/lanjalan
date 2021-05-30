using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekObject : MonoBehaviour
{
    [SerializeField] private bool isCorrect = false;

    private void OnMouseDown() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            transform.parent.gameObject.GetComponent<SeekManager>().NotifyUser(isCorrect);
        }
    }
}
