using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoree : MonoBehaviour
{
    
    [SerializeField] private Text scoreText;
   
    public int scoreFin;
    void Start()
    {
       
        scoreFin = PlayerPrefs.GetInt("scoreFin");
       
        scoreText.text = ": " + scoreFin;
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    public void quiz()
    {
        SceneManager.LoadScene("Quiz");
    }
}
