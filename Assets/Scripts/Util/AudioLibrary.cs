using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioLibrary", menuName = "ScriptableObjects/Audio/AudioLibrary", order = 1)]
public class AudioLibrary : ScriptableObject
{
    public AudioClip level1Track;
    public AudioClip deathTrack;

    public Dictionary<AudioLibraryEnum, AudioClip> audioMap = new Dictionary<AudioLibraryEnum, AudioClip>();

    private void OnEnable()
    {
        audioMap.Add(AudioLibraryEnum.Level1, level1Track);
        audioMap.Add(AudioLibraryEnum.Death, deathTrack);
    }
}

public enum AudioLibraryEnum
{
    Level1,
    Death
}