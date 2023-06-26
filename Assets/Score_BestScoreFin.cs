using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score_BestScoreFin : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text scoreText;
    public int bestSoreFin;
    public int scoreFin;
    void Start()
    {
        bestSoreFin = PlayerPrefs.GetInt("bestSoreFin");
        scoreFin = PlayerPrefs.GetInt("scoreFin");
        bestScoreText.text = "" + bestSoreFin;
        scoreText.text = ": " + scoreFin;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("bestSoreFin", bestSoreFin);
        PlayerPrefs.SetInt("scoreFin", scoreFin);
        bestScoreText.text = "" + bestSoreFin;
        scoreText.text = "" + scoreFin;

    }
    public void quiz()
    {
        SceneManager.LoadScene("Quiz");
    }
}
