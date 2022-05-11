using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData
{
    public Vector3 position;
    public Quaternion rotation;
    public string dialogueStart;
    public string dialogueEnd;
    public bool isMainStory;

    public NPCData(Vector3 initPosition, Quaternion initRotation, string initDialogueStart, string initDialogueEnd, bool initIsMainStory)
    {
        position = initPosition;
        rotation = initRotation;
        dialogueStart = initDialogueStart;
        dialogueEnd = initDialogueEnd;
        isMainStory = initIsMainStory;
    }
}
