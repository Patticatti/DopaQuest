using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {get; private set;}
    private AudioSource audioSource;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip) 
    {
        audioSource.PlayOneShot(audioClip);
    }
}
