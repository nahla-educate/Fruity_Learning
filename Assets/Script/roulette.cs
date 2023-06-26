using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class roulette : MonoBehaviour
{
    private int numberOfTurns;
    private int whatWeWin;
    private float speed;
    private bool canWeTurn;
    public Text winningText;
    public static ArrayList fruits = new ArrayList();
    static int c = 0;
    public int scoreGloball;
   
    void Start()
    {
        Debug.Log(scoreGloball);
        canWeTurn = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && canWeTurn == true)
        {
            StartCoroutine(TurnTheWheel());
        }
        if (Input.GetMouseButtonDown(0) && canWeTurn == true)
        {
            StartCoroutine(TurnTheWheel());
        }

    }

    private IEnumerator TurnTheWheel()
    {



        canWeTurn = false;
        //numberOfTurns = Random.Range(40, 60);
        
        if(c == 8)
        {
            /////Debug.Log("NEW SCENE");
            ///azjouter variable globale (score) enregistrer en memoire comme bestScore
            // quizApple.
            scoreGloball = PlayerPrefs.GetInt("scoreGloball");
            if(scoreGloball >= 96)
            {
                SceneManager.LoadScene("Win");
            }else if(scoreGloball < 96)
            {
                SceneManager.LoadScene("Lose");
            }
            c = 0;
            
        }
        
        bool redo = true;
        while (redo)
        {
            Debug.Log("c -- " + c);
            
                
            redo = false;
            numberOfTurns = Random.Range(0, 8) * 2 + 40;
            Debug.Log(fruits.Contains(numberOfTurns));
            if (fruits.Contains(numberOfTurns))
            {
                redo = true;
            }
            else
            {
                fruits.Add(numberOfTurns);
                c++;
            }
            if (c == 8)
            {
                fruits.Clear();
            }
        }
        speed = 0.01f;


        for (int i = 0; i < numberOfTurns; i++)
        {
            transform.Rotate(0, 0, 22.5f);

            if (i > Mathf.RoundToInt(numberOfTurns * 0.5f))
            {
                speed = 0.02f;


            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.7f))
            {
                speed = 0.03f;

            }
            if (i > Mathf.RoundToInt(numberOfTurns * 0.9f))
            {
                speed = 0.04f;

            }
            yield return new WaitForSeconds(speed);
        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.7f);
        }

        whatWeWin = Mathf.RoundToInt(transform.eulerAngles.z);
       

        if (whatWeWin >= 0 && whatWeWin <= 45)
        {
            winningText.text = "Apple";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        }
        if (whatWeWin > 45 && whatWeWin <= 90)
        {
            winningText.text = "Orange";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
        }
        if (whatWeWin > 90 && whatWeWin <= 135)
        {
            winningText.text = "Cherry";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
        }
        if (whatWeWin > 135 && whatWeWin <= 180)
        {
            winningText.text = "Pear";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
        }
        if (whatWeWin > 180 && whatWeWin <= 225)
        {
            winningText.text = "Peach";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
        }
        if (whatWeWin > 225 && whatWeWin <= 270)
        {
            winningText.text = "Banana";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
        if (whatWeWin > 270 && whatWeWin <= 315)
        {
            winningText.text = "Melon";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
        }
        if (whatWeWin > 315)
        {
            winningText.text = "Star";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);
        }
        /*switch (whatWeWin)
        {
            case 0:
                winningText.text = "Star";
                break;
            case 45:
                winningText.text = "Pomme";
                break;
            case 90:
                winningText.text = "Pastèque";
                break;
            case 135:
                winningText.text = "Grenade";
                break;
            case 180:
                winningText.text = "Cerise";
                break;
            case 225:
                winningText.text = "Orange";
                break;
            case 270:
                winningText.text = "Poire";
                break;
            case 315:
                winningText.text = "Kiwi";
                break;
            
        }*/
        canWeTurn = true;
    }
}
