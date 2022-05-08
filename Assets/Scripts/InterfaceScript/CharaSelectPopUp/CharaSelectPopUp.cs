using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectPopUp : MonoBehaviour
{
    [SerializeField] private int[] charaModelIndexs;
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
        for(int ind = 0; ind < charaModelIndexs.Length; ind++)
        {
            GameObject buttonObj = Instantiate(charaSelectButton, charaSelectButtonParent);
            int tempModelIndex = charaModelIndexs[ind];
            Sprite tempModelIcon = null;
            if(ind < charaModelIcons.Length)
            {
                tempModelIcon = charaModelIcons[ind];
            }
            buttonObj.GetComponent<Button>().onClick.AddListener(() => ChangeCharaModel(tempModelIndex));
            buttonObj.GetComponent<CharaSelectButton>().SetCharaModelButton(tempModelIcon);
        }
    }

    private void ChangeCharaModel(int modelIndex)
    {
        player.SetCharacterModel(modelIndex);
    }
}
