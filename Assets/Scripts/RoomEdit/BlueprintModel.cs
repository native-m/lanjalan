using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintModel : MonoBehaviour
{
    private bool isAnyObjectInside = false;
    public bool IsAnyObjectInside { get { return isAnyObjectInside; } }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            return;
        }
        isAnyObjectInside = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            return;
        }
        isAnyObjectInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isAnyObjectInside = false;
    }
}
