using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEditManager : MonoBehaviour
{
    private static RoomEditManager _instance = null;
    public static RoomEditManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RoomEditManager>();
            }
            return _instance;
        }
    }

    private bool isPlacingDecor = false;

    private RaycastHit hit;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(isPlacingDecor)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 50000f, (1 << LayerMask.NameToLayer("DecorObject"))))
            {
                if(hit.transform.tag == "AdditionalDecor")
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }
    }

    public void SpawnBlueprint(GameObject blueprintPref)
    {
        if(!isPlacingDecor)
        {
            isPlacingDecor = true;
            Instantiate(blueprintPref);
        }
    }

    public void SetPlacingDecor(bool value)
    {
        isPlacingDecor = value;
    }
}
