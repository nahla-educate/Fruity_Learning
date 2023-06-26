using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    float score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score += 3 * Time.deltaTime;
        PlayerPrefs.SetInt("Score", (int)score);
        ScoreText.text = "Score: " + (int)score;
        if (PlayerPrefs.GetInt("BestScore") < score)
        {
            PlayerPrefs.SetInt("BestScore", (int)score);
        }
    }
}
