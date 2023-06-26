using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public AudioMixer audioMixer;
    
   /*public void PlayGame ()
    {
        SceneManager.LoadScene("option");
    }*/
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);

    }

}
