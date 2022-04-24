using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectPopUp : MonoBehaviour
{
    [SerializeField] private string[] charaModelPaths;
    [SerializeField] private Sprite[] charaModelIcons;
    [SerializeField] private GameObject charaSelectButton;
    [SerializeField] private Transform charaSelectButtonParent;

    [SerializeField] private Player player;

    private void Start()
    {
        InititateCharaSelection();
    }

    private void InititateCharaSelection()
    {
        for(int ind = 0; ind < charaModelPaths.Length; ind++)
        {
            GameObject buttonObj = Instantiate(charaSelectButton, charaSelectButtonParent);
            string tempModelPath = charaModelPaths[ind];
            Sprite tempModelIcon = null;
            if(ind < charaModelIcons.Length)
            {
                tempModelIcon = charaModelIcons[ind];
            }
            buttonObj.GetComponent<Button>().onClick.AddListener(() => ChangeCharaModel(tempModelPath));
            buttonObj.GetComponent<CharaSelectButton>().SetCharaModelButton(tempModelIcon);
        }
    }

    private void ChangeCharaModel(string modelPath)
    {
        player.SetCharacterModel(modelPath);
    }
}
