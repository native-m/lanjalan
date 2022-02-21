using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPopUpManager : MonoBehaviour
{
    [SerializeField] private bool isSoundOn = true;
    [SerializeField] private SoundToggle[] soundToggles;

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
        foreach(SoundToggle soundToggle in soundToggles)
        {
            soundToggle.SetSelected(soundToggle.IsOnToggle == isSoundOn);
        }
    }
}
