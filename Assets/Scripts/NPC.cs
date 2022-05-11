using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private string npcCode = "default";
    private string dialogueStart = "defaultStart";
    private string dialogueEnd = "defaultEnd";
    private bool isDialogueMainStory = false;

    public string DialogueStart { get { return dialogueStart; } }
    public string DialogueEnd { get { return dialogueEnd; } }

    public bool IsDialogueMainStory { get { return isDialogueMainStory; } }

    private void Start()
    {
        /*print(name + " " + transform.position.ToString() + " " + transform.rotation.ToString());*/
        if(npcCode != "default")
        {
            if (Chapter1Manager.Instance != null)
            {
                Chapter1Manager ch1Manager = Chapter1Manager.Instance;
                if (ch1Manager.NPCDatabase.ContainsKey(npcCode))
                {
                    NPCData npcData = ch1Manager.NPCDatabase[npcCode];
                    transform.position = npcData.position;
                    transform.rotation = npcData.rotation;
                    dialogueStart = npcData.dialogueStart;
                    dialogueEnd = npcData.dialogueEnd;
                    isDialogueMainStory = npcData.isMainStory;
                }
            }
        }
    }

    public void SetDialogueCode(string startCode, string endCode, bool isMainStory)
    {
        dialogueStart = startCode;
        dialogueEnd = endCode;
        isDialogueMainStory = isMainStory;
    }
}
