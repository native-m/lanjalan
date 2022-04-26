using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private GameObject popUpBgLayer;
    [SerializeField] private GameObject howToPlayLayer;
    [SerializeField] private GameObject questionLayer;
    [SerializeField] private GameObject endLayer;
    [SerializeField] private Text questionText;
    [SerializeField] private Text questionTimerText;
    [SerializeField] private Text playerTimerText;

    [SerializeField] private LetterTileAreaController letterTileAreaCont;

    [SerializeField] private Transform answerArea;
    [SerializeField] private Transform letterArea;

    private List<LetterTile> answerSlots = new List<LetterTile>();
    private int maxSlotAmount = 9;
    private int currentSlotLimit = 0;

    //Temp Database//

    private List<string> questionList = new List<string>
    {
        "Apa nama desa ini ?",
        "Kerajaan apakah ini?",
        "Siapa raja kerajaan in?",
    };

    private List<string> answerList = new List<string>
    {
        "BUGISAN",
        "PRAMBANAN",
        "PRABUBAKA",
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

    private bool isQuestionShown = false;
    private float questionShownDuration = 10f;
    private float questionTimer = 0f;

    private TimeSpan timePlaying;
    private bool isPlayerTimerOn = false;
    private float playerTimer = 0f;

    private void Start()
    {
        popUpBgLayer.SetActive(true);
        howToPlayLayer.SetActive(true);
        questionLayer.SetActive(false);
    }

    private void Update()
    {
        QuestionTimerHandler();
        PlayerTimerHandler();
    }

    public void StartGame()
    {
        howToPlayLayer.SetActive(false);
        popUpBgLayer.SetActive(false);
        ShowCurrentQuestion();
        BeginPlayerTimer();
    }
    private void ShowCurrentQuestion()
    {
        popUpBgLayer.SetActive(true);
        questionLayer.SetActive(true);
        questionText.text = questionList[currentAnswerIndex];
        StartQuestionTimer();
    }

    private void StartQuestionTimer()
    {
        questionTimer = questionShownDuration;
        isQuestionShown = true;
    }

    private void QuestionTimerHandler()
    {
        if(isQuestionShown)
        {
            if(questionTimer > 0)
            {
                questionTimer -= Time.deltaTime;
                int remainingTimeInt = Mathf.CeilToInt(questionTimer);
                questionTimerText.text = remainingTimeInt.ToString();
            }
            else
            {
                isQuestionShown = false;
                questionLayer.SetActive(false);
                popUpBgLayer.SetActive(false);
                SetUpForCurrentAnswer();
            }
        }
    }

    private void BeginPlayerTimer()
    {
        playerTimer = 0f;
        isPlayerTimerOn = true;
    }

    private void PlayerTimerHandler()
    {
        if(isPlayerTimerOn)
        {
            playerTimer += Time.deltaTime;
        }
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
            ShowCurrentQuestion();
        }
        else
        {
            GameEndHandler();
        }
    }

    private void GameEndHandler()
    {
        isPlayerTimerOn = false;
        popUpBgLayer.SetActive(true);
        endLayer.SetActive(true);
        timePlaying = TimeSpan.FromSeconds(Mathf.FloorToInt(playerTimer));
        string timePlayingStr = timePlaying.ToString();
        playerTimerText.text = timePlayingStr;
    }
}
