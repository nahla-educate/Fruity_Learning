using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeachQuizManager : MonoBehaviour
{
    [SerializeField] private PeachQuizUI quizUI;
    [SerializeField] private PeachDataScriptable quizData;
    [SerializeField] Timer time1;
    [SerializeField] private Text numQuizText;

    private int numQuiz;
    public int score;
    public int bestSore;
    public int scoreGloball;
    private int i = 0;

    private List<QuestionPeach> questions;
    private QuestionPeach selectedQuestion;
    // Start is called before the first frame update
    void Start()
    {
        bestSore = PlayerPrefs.GetInt("BestScore");
        scoreGloball = PlayerPrefs.GetInt("scoreGloball");
        questions = quizData.questions;
        SelectQuestion();

        quizUI.BestScoreText.text = "BestScore: " + bestSore;
        quizUI.ScoreText.text = "Score: " + score;
    }

    void SelectQuestion()
    {

        i++;
        if (i == 1)
        {
            // int val = Random.Range(0, questions.Count);
            // time1.SetDuration(10).Begin();
            selectedQuestion = questions[1];
            // Debug.Log(val);
            // Debug.Log(selectedQuestion);
            Debug.Log("i****" + i);
            quizUI.SetQuestion(selectedQuestion);
            PlayerPrefs.SetInt("i", i);
            Debug.Log("i****new" + i);

            numQuizText.text = "" + 1;
        }
        else if (i == 2)
        {
            //int val = Random.Range(0, questions.Count);
            //time1.SetDuration(10).Begin();
            selectedQuestion = questions[2];
            //  Debug.Log(val);
            //  Debug.Log(selectedQuestion);
            Debug.Log("i****" + i);
            quizUI.SetQuestion(selectedQuestion);
            numQuizText.text = "" + 2;
        }
        else if (i == 3)
        {
            // time1.SetDuration(10).Begin();
            selectedQuestion = questions[0];
            //  Debug.Log(val);
            //  Debug.Log(selectedQuestion);
            Debug.Log("i****" + i);
            quizUI.SetQuestion(selectedQuestion);
            numQuizText.text = "" + 3;
        }
        else if (i == 4)
        {
            // time1.SetDuration(10).Begin();
            selectedQuestion = questions[3];
            //  Debug.Log(val);
            //  Debug.Log(selectedQuestion);
            Debug.Log("i****" + i);
            quizUI.SetQuestion(selectedQuestion);
            numQuizText.text = "" + 4;
        }
        else
        {
            SceneManager.LoadScene("Roulette");
        }

    }
    public bool Answer(string answered)
    {
        bool correctAns = false;
        quizUI.BestScoreText.text = "BestScore: " + bestSore;
        quizUI.ScoreText.text = "Score: " + score;
        if (answered == selectedQuestion.correctAns)
        {
            //yes
            correctAns = true;
            score += 6;
            quizUI.ScoreText.text = "Score: " + score;
            PlayerPrefs.SetInt("scoreGloball", (scoreGloball + score));

            Debug.Log("****" + scoreGloball);
            // quizUI.BestScoreText.text = "BestScore: " + bestSore;

            if (bestSore < score)
            {
                PlayerPrefs.SetInt("BestScore", (int)score);
                quizUI.BestScoreText.text = "BestScore: " + bestSore;
            }
        }
        else
        {
            //no
        }
        Invoke("SelectQuestion", 0.4f);
        return correctAns;
    }
}

[System.Serializable]
public class QuestionPeach
{
    public string questionInfo;
    public QuestionPeachType questionType;
    public Sprite questionImg;
    public AudioClip questionClip;
    public UnityEngine.Video.VideoClip questionVideo;
    public List<string> options;
    public string correctAns;
}

[System.Serializable]
public enum QuestionPeachType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}

