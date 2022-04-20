using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumHUDController : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject decorPanel;
    private bool isDecorMode = false;

    private void Start()
    {
        SetDecodMode(false);
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
