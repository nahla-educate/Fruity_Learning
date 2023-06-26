using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int i;
    [Header("Timer UI references :")]
    [SerializeField] private Text uiText;
    [SerializeField] private Image uiFillImage;
    [SerializeField] private AudioSource correctAnsSound;
    [SerializeField] Timer time1;

   
    public int Duration { get; private set; }
    public int remainingDuration;

    
    private void Awake()
    {
        ResetTimer();
    }

    // Update is called once per frame
    private void ResetTimer()
    {
        uiText.text = "00:00";
        uiFillImage.fillAmount = 0f;

        Duration = remainingDuration = 0;

    }

    public Timer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            if (remainingDuration <= 3)
            {
                correctAnsSound.Play();
            }
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    internal object SetDuration()
    {
        throw new NotImplementedException();
    }

    private void UpdateUI(int seconds)
    {
        uiText.text = string.Format("{0:D2}:{1:D2}", seconds/60, seconds%60);
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
        
    }

    public void End()
    {
        ResetTimer();
      //  i = PlayerPrefs.GetInt("i")+1;
       
      //  Debug.Log("i****new" + i);

         SceneManager.LoadScene("Roulette");
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
