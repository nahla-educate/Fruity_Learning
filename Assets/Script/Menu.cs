using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void HomeQuizALL()
    {
        SceneManager.LoadScene("Accueil");
    }
   // public int scoreGloball = 0;
    public void PlayGame()
    {
        PlayerPrefs.SetInt("scoreGloball", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Instruction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void HomeQuiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void QuiGame()
    {
        Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HomeRoulette()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuiGameRoulette()
    {
        Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

}
