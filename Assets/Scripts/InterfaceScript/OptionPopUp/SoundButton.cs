using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private bool isOnButton;
    [SerializeField] private Image checkmarkImage;
    public bool IsOnButton { get { return isOnButton; } }

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetSelected(bool _isSelected)
    {
        checkmarkImage.enabled = _isSelected;
        button.interactable = !_isSelected;
    }
}
