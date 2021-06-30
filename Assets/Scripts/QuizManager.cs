using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] optionTexts;
    [SerializeField] private Button[] optionButtons;
    [SerializeField] private TextMeshProUGUI respondText;
    [SerializeField] private Slider timerBar;

    [SerializeField] private Animator roroAnimator;

    private float timer = 10f;

    private int quizIndex = 0;
    private string[] questionArray = 
    {
        "Siapa nama dari raja kerjaan ini?",
        "Apa nama desa ini",
        "Kerajaan mataram kuno sedang berperang melawan kerajaan apa  ?"
    };
    private string[,] optionArray =
    {
        {"Prabu Baka", "Prabu Wongso", "Ayam Wuruk"},
        {"Desa Bugisan", "Desa Hijau", "Desa Perahu"},
        {"Kerajaan Pengging", "Kerajaan Ponggang", "Kerajaan Pinggung"},
    };
    private int[] answerArray = {0, 0, 0};

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
        timer = 10f;
        roroAnimator.Play("RoroQuizBertanya");
    }

    public void Answering(int choice)
    {
        if(choice == answerArray[quizIndex])
        {
            quizIndex++;
            if(quizIndex == questionArray.Length)
            {
                quizIndex = 0;
                foreach(Button button in optionButtons)
                {
                    button.interactable = false;
                }
                respondText.SetText("Wow kamu sudah seperti penduduk desa ini saja! Kamu cocok untuk tinggal di desa ini.");
                timer = 0f;
            }
            else
            {
                UpdateQuiz();
            }
        }
    }
}
