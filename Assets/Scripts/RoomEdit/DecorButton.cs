using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecorButton : MonoBehaviour
{
    [SerializeField] private Text buttonText;
    
    private GameObject blueprintPrefab;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    public void SetupButton(GameObject prefab, string name)
    {
        blueprintPrefab = prefab;
        buttonText.text = name;
    }

    private void ButtonClicked()
    {
        if (RoomEditManager.Instance != null)
        {
            RoomEditManager.Instance.SpawnBlueprint(blueprintPrefab);
        }

    }
}
