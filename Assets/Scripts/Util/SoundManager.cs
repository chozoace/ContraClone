using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private int currentLevel = 0;
    //Level, Death, Pause, Boss
    public AudioLibrary level1Sounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();   
    }

    public void ChangeTrack(int trackEnum)
    {
        AudioClip clip = level1Sounds.audioMap[(AudioLibraryEnum)trackEnum];
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PauseTrack()
    {
        audioSource.Pause();
    }

    public void ResumeTrack()
    {
        audioSource.Play();
    }
}
