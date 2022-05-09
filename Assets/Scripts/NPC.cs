using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private string dialogueStart = "defaultStart";
    [SerializeField] private string dialogueEnd = "defaultEnd";

    public string DialogueStart { get { return dialogueStart; } }
    public string DialogueEnd { get { return dialogueEnd; } }
}
