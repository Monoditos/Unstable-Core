using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : Singleton
{
    private Audio[] musicAudio;
    private Audio[] sfxAudio;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Start()
    {
        musicAudio = Resources.LoadAll<Audio>("Audio/Music");
        sfxAudio = Resources.LoadAll<Audio>("Audio/SFX");
    }
    
}

