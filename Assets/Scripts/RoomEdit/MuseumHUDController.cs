using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumHUDController : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject decorPanel;
    [SerializeField] private GameObject mainPopUpCanvas;
    [SerializeField] private GameObject[] popUps;
    private bool isDecorMode = false;
    private bool isPopUpOpen = false;
    private int currentPopUp = -1;

    private void Start()
    {
        SetDecodMode(false);
        InitialPopUpHandler();
    }

    private void InitialPopUpHandler()
    {
        isPopUpOpen = false;
        mainPopUpCanvas.SetActive(false);
        foreach(GameObject popUp in popUps)
        {
            popUp.SetActive(false);
        }
    }

    public void TogglePopUp(int popUpIndex)
    {
        if (isPopUpOpen)
        {
            if (popUpIndex == currentPopUp)
            {
                TogglePopUp(false, popUpIndex);
            }
        }
        else
        {
            TogglePopUp(true, popUpIndex);
        }
    }

    private void TogglePopUp(bool isOpen, int popUpIndex)
    {
        isPopUpOpen = isOpen;
        mainPopUpCanvas.SetActive(isOpen);
        popUps[popUpIndex].SetActive(isOpen);
        if (isOpen)
        {
            currentPopUp = popUpIndex;
        }
        else
        {
            currentPopUp = -1;
        }
    }

    public void SetDecodMode(bool value)
    {
        isDecorMode = value;
        ToogleDecorMode();
    }

    private void ToogleDecorMode()
    {
        decorPanel.SetActive(isDecorMode);
        hud.SetActive(!isDecorMode);
    }
}
