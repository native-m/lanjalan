using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeekManager : MonoBehaviour
{
    private SeekObject[] seekObjects;
    [SerializeField] private TextMeshProUGUI notificationText;
    private float resetTextDelay = 1f;

    private void Start()
    {
        seekObjects = FindObjectsOfType<SeekObject>();      
    }

    public void NotifyUser(bool isCorrect)
    {
        if(isCorrect)
        {
            notificationText.SetText("Benar");
        }
        else
        {
            notificationText.SetText("Bukan Itu");
        }
        Invoke("ResetText", resetTextDelay);
    }

    private void ResetText()
    {
        notificationText.SetText("");
    }
}
