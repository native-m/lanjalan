using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterButton : MonoBehaviour
{
    [SerializeField] private Text buttonText;
    [SerializeField] private Sprite[] buttonSprites;
    private Button button;
    private Image buttonImage;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

    public void SetButton(string buttonString, bool isUnlocked)
    {
        /*buttonText.text = buttonString;
        button.interactable = isUnlocked;
        buttonImage.sprite = buttonSprites[System.Convert.ToInt32(isUnlocked)];*/
    }
}
