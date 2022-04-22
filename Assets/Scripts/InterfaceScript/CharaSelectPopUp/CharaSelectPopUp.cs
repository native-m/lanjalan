using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectPopUp : MonoBehaviour
{
    [SerializeField] private string[] charaModelPaths;
    [SerializeField] private GameObject charaSelectButton;
    [SerializeField] private Transform charaSelectButtonParent;

    [SerializeField] private Player player;

    private void Start()
    {
        InititateCharaSelection();
    }

    private void InititateCharaSelection()
    {
        foreach(string charaModelPath in charaModelPaths)
        {
            GameObject buttonObj = Instantiate(charaSelectButton, charaSelectButtonParent);
            buttonObj.GetComponent<CharaSelectButton>().SetCharaModelButton(charaModelPath);
            buttonObj.GetComponent<Button>().onClick.AddListener(() => ChangeCharaModel(charaModelPath));
        }
    }

    private void ChangeCharaModel(string modelPath)
    {
        player.SetCharacterModel(modelPath);
    }
}
