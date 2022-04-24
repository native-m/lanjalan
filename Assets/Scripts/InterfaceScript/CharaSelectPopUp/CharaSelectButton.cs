using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaSelectButton : MonoBehaviour
{
    [SerializeField] private Image buttonModelIcon;
    private string charaModelPath;

    public void SetCharaModelButton(Sprite icon)
    {
        if(icon != null)
        {
            buttonModelIcon.sprite = icon;
        }
    }
}
