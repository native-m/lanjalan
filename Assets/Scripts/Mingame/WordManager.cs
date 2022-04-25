using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    private static WordManager _instance = null;
    public static WordManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<WordManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private LetterTileAreaController letterTileAreaCont;

    [SerializeField] private Transform answerArea;
    [SerializeField] private Transform letterArea;

    private List<LetterTile> answerSlots = new List<LetterTile>();
    private int maxSlotAmount = 9;
    private int currentSlotLimit = 0;

    //Temp Database//
    private List<string> answerList = new List<string>
    {
        "BUGISAN",
        "PRAMBANAN",
    };

    private int currentAnswerIndex = 0;
    public string CurrentAnswer 
    {
        get 
        {
            if(currentAnswerIndex < answerList.Count)
            {
                return answerList[currentAnswerIndex];
            }
            else
            {
                return "";
            }
        }
    }

    private void Start()
    {
        SetUpForCurrentAnswer();
    }

    private void SetUpForCurrentAnswer()
    {
        ClearAnswerSlot();
        UpdateSlotLimit();
        letterTileAreaCont.InitiateTiles(CurrentAnswer);
    }

    private void ClearAnswerSlot()
    {
        foreach (LetterTile answerSlot in answerSlots)
        {
            Destroy(answerSlot.gameObject);
        }

        answerSlots.Clear();
    }

    private void UpdateSlotLimit()
    {
        if(CurrentAnswer != "")
        {
            currentSlotLimit = CurrentAnswer.Length;
        }
        else
        {
            currentSlotLimit = maxSlotAmount;
        }
    }

    public void MoveToAnswerArea(LetterTile tile)
    {
        if(answerSlots.Count < currentSlotLimit)
        {
            answerSlots.Add(tile);
            tile.transform.parent = answerArea;
            tile.transform.localPosition = new Vector3(-6f + ((answerSlots.Count - 1f) * 1.5f), 0, 0);
            tile.SetIsInAnswer(true);
            CheckIfCorrect();
        }
        
    }

    public void MovetoLetterArea(LetterTile tile)
    {
        int tileIndex = answerSlots.FindIndex((x) => x.TileId == tile.TileId);
        if(tileIndex != -1)
        {
            answerSlots[tileIndex].transform.parent = letterArea;
            answerSlots[tileIndex].transform.localPosition = answerSlots[tileIndex].GetInitialPositiion();
            answerSlots.RemoveAt(tileIndex);
            tile.SetIsInAnswer(false);
        }
        for(int i = tileIndex; i < answerSlots.Count; i++)
        {
            answerSlots[i].transform.localPosition = new Vector3(answerSlots[i].transform.localPosition.x - 1.5f, answerSlots[i].transform.localPosition.y, answerSlots[i].transform.localPosition.z);
        }
    }

    private void CheckIfCorrect()
    {
        if(answerSlots.Count > CurrentAnswer.Length)
        {
            return;
        }

        string playerAnswer = GetPlayerAnswer();
        if(playerAnswer == CurrentAnswer)
        {
            CorrectAnswerHandler();
        }
    }

    private string GetPlayerAnswer()
    {
        string playerAnswer = "";
        foreach(LetterTile answerSlot in answerSlots)
        {
            playerAnswer += answerSlot.TileLetter;
        }

        return playerAnswer;
    }

    private void CorrectAnswerHandler()
    {
        if(currentAnswerIndex < answerList.Count - 1)
        {
            currentAnswerIndex++;
            SetUpForCurrentAnswer();
        }
        else
        {
            print("Game End");
        }
    }
}
