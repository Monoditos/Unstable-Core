using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] musicAudio;
    [SerializeField]
    private AudioClip[] sfxAudio;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Start()
    {
        musicAudio = Resources.LoadAll<AudioClip>("Audio/Music");
        sfxAudio = Resources.LoadAll<AudioClip>("Audio/SFX");

        PlayMusic("music_ES04");
    }

    public void PlayMusic(string name)
    {
        foreach (AudioClip audio in musicAudio)
        {
            if (audio.name == name)
            {
                musicSource.clip = audio;
                musicSource.Play();
                return;
            }
        }
    }
    
}

