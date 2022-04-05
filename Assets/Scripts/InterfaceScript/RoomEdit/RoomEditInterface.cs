using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEditInterface : MonoBehaviour
{
    [SerializeField] private GameObject[] decorBlueprintPrefabs;
    [SerializeField] private string[] decorNames;
    [SerializeField] private GameObject decorButtonPrefab;
    [SerializeField] private Transform decorButtonParent;

    private void Start()
    {
        InitializeDecorList();
    }

    private void InitializeDecorList()
    {
        for(int index = 0; index < decorBlueprintPrefabs.Length; index++)
        {
            GameObject tempButton = Instantiate(decorButtonPrefab, decorButtonParent);
            tempButton.GetComponent<DecorButton>().SetupButton(decorBlueprintPrefabs[index], decorNames[index]);
        }
    }
}
