using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private bool isOnToggle;
    public bool IsOnToggle { get { return isOnToggle; } }

    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void SetSelected(bool _isSelected)
    {
        toggle.isOn = _isSelected;
        toggle.interactable = !_isSelected;
    }
}
