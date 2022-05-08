using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPopUpManager : MonoBehaviour
{
    //Dummy Database
    private string[] buttonsText = { 
        "Chapter 1", 
        "Chapter 2", 
        "Coming Soon" 
    };
    private bool[] areButtonsUnlocked = { 
        true, 
        false, 
        false 
    };

    [SerializeField] private Transform chapterButtonParent;
    [SerializeField] private GameObject chapterButton;

    private void OnEnable()
    {
        for (int bttnIndex = 0; bttnIndex < buttonsText.Length; bttnIndex++)
        {
            GameObject newChButtonObj = Instantiate(chapterButton, chapterButtonParent);
            ChapterButton newChButton = newChButtonObj.GetComponent<ChapterButton>();

            newChButton.SetButton(buttonsText[bttnIndex], areButtonsUnlocked[bttnIndex]);
        }
    }

    private void Start()
    {
        
    }
}
