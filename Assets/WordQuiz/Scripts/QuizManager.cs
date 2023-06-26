using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private QuizDataScriptable questionData;

    [SerializeField]
    private Image questionImage;

    [SerializeField]
    private WordData[] answerWordArray;
    [SerializeField]
    private WordData[] optionsWordArray;

    private char[] charArray = new char[12];

    private int currentAnswerIndex = 0;
    private bool correctAnswer = true;

    public int scoreFin;
    public int bestSoreFin;

    private List<int> selectedWordIndex;
    private int currentQuestionIndex = 0;
    private GameStatus gameStatus = GameStatus.Playing;
    private string answerWord;
   // private int score = 0;
    [SerializeField] private Text scoreText, bestscoreText;

    public Text ScoreText { get { return scoreText; } }
    public Text BestScoreText { get { return bestscoreText; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
            Destroy(gameObject);
        selectedWordIndex = new List<int>();
    }

    private void Start()
    {
       
        SetQuestion();
        bestSoreFin = PlayerPrefs.GetInt("bestSoreFin");
        BestScoreText.text = "BestScore: " + bestSoreFin;
        ScoreText.text = "Score: " + scoreFin;
    }
    private void SetQuestion()
    {
        currentAnswerIndex = 0;
        selectedWordIndex.Clear();


        questionImage.sprite = questionData.questions[currentQuestionIndex].questionImage;
        answerWord = questionData.questions[currentQuestionIndex].answer;
        
        ResetQuestion();
       
        for (int i = 0; i < answerWord.Length; i++)
        {
            charArray[i] = char.ToUpper(answerWord[i]);
        }
        for (int i = answerWord.Length; i < optionsWordArray.Length; i++)
        {
            charArray[i] = (char)UnityEngine.Random.Range(65, 91);
        }
        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();

        for(int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].SetChar(charArray[i]);
        }

        currentQuestionIndex++;
        gameStatus = GameStatus.Playing;

    }

    public void SelectedOption(WordData wordData)
    {
        if (gameStatus == GameStatus.Next || currentAnswerIndex >= answerWord.Length) return;

        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());
        answerWordArray[currentAnswerIndex].SetChar(wordData.charValue);
        wordData.gameObject.SetActive(false);
        currentAnswerIndex++;

        if (currentAnswerIndex == answerWord.Length)
        {
            correctAnswer = true;

            for(int i =0; i< answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordArray[i].charValue))
                {
                    correctAnswer = false;
                    break;
                }
            }
            if (correctAnswer)
            {
                
                gameStatus = GameStatus.Next;
                scoreFin += 50;
                ScoreText.text = "Score: " + scoreFin;

                Debug.Log("we have answeered correct:" + scoreFin);
                if (bestSoreFin < scoreFin)
                {
                    PlayerPrefs.SetInt("bestSoreFin", (int)scoreFin);
                    BestScoreText.text = "BestScore: " + bestSoreFin;
                }


                if (currentQuestionIndex < questionData.questions.Count)
                {
                    Invoke("SetQuestion", 0.5f);

                }
                else
                {
                    if (scoreFin >= 200)
                    {

                        SceneManager.LoadScene("WinFin");

                    }
                    else if (scoreFin < 200)
                    {
                        SceneManager.LoadScene("LoseFin");
                    }

                }


            }
            else if (!correctAnswer)
            {
                Debug.Log("we have not answeered correct");
                Invoke("SetQuestion", 0.5f);
            }
        }
    } 
    
    private void ResetQuestion()
    {
        for (int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetChar('_');

        }
        for (int i = answerWord.Length; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(false);
            

        }
        for (int i =0; i< optionsWordArray.Length; i++ )
        {
            optionsWordArray[i].gameObject.SetActive(true);
        }
        
    }

   
}
[System.Serializable]
public class QuestionData
{
    public Sprite questionImage;
    public string answer;

}
public enum GameStatus
{
    Playing,
    Next
}