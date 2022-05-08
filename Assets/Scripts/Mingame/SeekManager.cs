using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeekManager : MonoBehaviour
{
    /*private SeekObject[] seekObjects;*/
    [SerializeField] private TextMeshProUGUI notificationText;
    private float resetTextDelay = 1f;

    [SerializeField] private GameObject popUpBgLayer;
    [SerializeField] private GameObject howToPlayLayer;
    [SerializeField] private GameObject endLayer;
    [SerializeField] private Text playerTimerText;

    private TimeSpan timePlaying;
    private bool isPlayerTimerOn = false;
    private float playerTimer = 0f;
    private bool isGameStart = false;

    private void Start()
    {
        /*seekObjects = FindObjectsOfType<SeekObject>();*/
        popUpBgLayer.SetActive(true);
        howToPlayLayer.SetActive(true);
        endLayer.SetActive(false);
    }

    private void Update()
    {
        PlayerTimerHandler();
    }

    public void NotifyUser(bool isCorrect)
    {
        if(!isGameStart)
        {
            return;
        }

        if(isCorrect)
        {
            notificationText.SetText("Benar");
            GameEndHandler();
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

    public void StartGame()
    {
        howToPlayLayer.SetActive(false);
        popUpBgLayer.SetActive(false);
        BeginPlayerTimer();
        isGameStart = true;
    }

    private void BeginPlayerTimer()
    {
        playerTimer = 0f;
        isPlayerTimerOn = true;
    }

    private void PlayerTimerHandler()
    {
        if (isPlayerTimerOn)
        {
            playerTimer += Time.deltaTime;
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
