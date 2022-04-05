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
