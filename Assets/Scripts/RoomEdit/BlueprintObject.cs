using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintObject : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private RaycastHit hit;
    [SerializeField] private BlueprintModel blueprintModel;


    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 50000f, (1 << LayerMask.NameToLayer("Ground"))))
        {
            transform.position = hit.point;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000f, (1 << LayerMask.NameToLayer("Ground"))))
        {
            transform.position = hit.point; 
        }

        if(Input.GetMouseButton(0))
        {
            if(blueprintModel.IsAnyObjectInside)
            {
                return;
            }

            Instantiate(objectPrefab, transform.position, transform.rotation);
            if (RoomEditManager.Instance != null)
            {
                RoomEditManager.Instance.SetPlacingDecor(false);
            }
            Destroy(gameObject);
        }
        else if (Input.GetMouseButton(1))
        {
            if (RoomEditManager.Instance != null)
            {
                RoomEditManager.Instance.SetPlacingDecor(false);
            }
            Destroy(gameObject);
        }
    }
}

