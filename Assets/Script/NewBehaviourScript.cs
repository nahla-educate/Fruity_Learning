using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;
//using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public static NewBehaviourScript instance { get; private set; }
    public AudioSource Source;
    private void Awake()
    {
        instance = this;
        Source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _sound)
    {
        Source.PlayOneShot(_sound);
    }
    
}
/* public static NewBehaviourScript instance;

private void Awake()
{
DontDestroyOnLoad(this.gameObject);

if (instance == null)
{
    instance = this;
}
else
{
    Destroy(gameObject);
}
}*/

