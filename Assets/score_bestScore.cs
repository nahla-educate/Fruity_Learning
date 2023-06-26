using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_bestScore : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text scoreGloballText;
    public int bestSore;
    public int scoreGloball;
    // Start is called before the first frame update
    void Start()
    {
        bestSore = PlayerPrefs.GetInt("BestScore");
        scoreGloball = PlayerPrefs.GetInt("scoreGloball");
       bestScoreText.text = "" + bestSore;
        scoreGloballText.text = ": " + scoreGloball;
    }

    // Update is called once per frame
    void Update()
    {
       PlayerPrefs.SetInt("BestScore", bestSore);
        PlayerPrefs.SetInt("scoreGloball", scoreGloball);
        bestScoreText.text = "" + bestSore;
        scoreGloballText.text = "" + scoreGloball;

    }
}
