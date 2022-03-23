using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEditManager : MonoBehaviour
{
    [SerializeField] private GameObject blueprinPref;

    public void SpawnBlueprint()
    {
        Instantiate(blueprinPref);
    }
}
