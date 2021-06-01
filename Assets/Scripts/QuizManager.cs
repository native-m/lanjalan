using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] optionTexts;
    [SerializeField] private Slider timerBar;

    private float timer = 40f;

    private int quizIndex = 0;
    private string[] questionArray = 
    {
        "Big PP Nation",
        "YEAAHHHHH BABBY THAT'S WHAT I'M TALKING ABOUT",
        "BRRUUHHHH"
    };
    private string[,] optionArray =
    {
        {"HentiBoy", "TheMonk", "Monkee"},
        {"G", "U", "H"},
        {"BRRRRRUUUUUUUUUUUUU", "UUUUUUUUUUUUUUUUUU", "UUUUUUUUUHHHHHHH"},
    };
    private int[] answerArray = {2, 1, 0};

    private void Start() 
    {
        UpdateQuiz();
        timerBar.maxValue = timer;
        timerBar.value = timer;
    }

    private void Update() 
    {
        UpdateTimer();    
    }

    private void UpdateTimer()
    {
        if(timer >= 0f)
        {
            timer -= Time.deltaTime;
            timerBar.value = timer;
        }
    }

    private void UpdateQuiz()
    {
        questionText.SetText(questionArray[quizIndex]);
        for(int i = 0; i < questionArray.Length; i++)
        {
            optionTexts[i].SetText(optionArray[quizIndex, i]);
        }
    }

    public void Answering(int choice)
    {
        if(choice == answerArray[quizIndex])
        {
            quizIndex++;
            if (quizIndex == questionArray.Length)
            {
                quizIndex = 0;
            }

            UpdateQuiz();
        }
    }
}
