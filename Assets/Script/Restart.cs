using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // SceneManager.LoadScene("Quiz");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Roulette()
    {
        SceneManager.LoadScene("Roulette");
    }
    public void QuizNextApple()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
    public void QuizNextPear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +9);
    }
    public void QuizNextPeach()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +9);
    }
    public void QuizNextBanana()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +9);
    }
    public void QuizNextMelon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +8);
    }
    public void QuizNextStar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +6);
    }
    public void QuizNextCherry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +8);
    }
    public void QuizNextOrange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +8);
    }

}
