using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPopUpManager : MonoBehaviour
{
    [SerializeField] private bool isSoundOn = true;
    [SerializeField] private SoundButton[] soundButtons;

    private void Start()
    {
        UpdateSoundToggles();
    }

    public void SoundToggled(bool _isSoundOn)
    {
        isSoundOn = _isSoundOn;
        UpdateSoundToggles();
    }

    private void UpdateSoundToggles()
    {
        foreach(SoundButton soundButton in soundButtons)
        {
            soundButton.SetSelected(soundButton.IsOnButton == isSoundOn);
        }
    }
}
