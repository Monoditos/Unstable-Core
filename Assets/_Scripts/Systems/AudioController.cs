using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;

    [SerializeField]
    private AudioClip[] musicAudio;
    [SerializeField]
    private AudioClip[] sfxAudio;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicAudio = Resources.LoadAll<AudioClip>("Audio/Music");
        sfxAudio = Resources.LoadAll<AudioClip>("Audio/SFX");
        
        PlaySoundEffect("ambient_noise_01");
    }

    void Update(){
        if(EventController.GetInstability != null){
            if(EventController.GetInstability >= 20 && EventController.GetInstability < 40){
                if( musicSource.clip.name != "music_ES01"){
                    PlayMusic("music_ES01");
                }
            }else if(EventController.GetInstability >= 40 && EventController.GetInstability < 60){
                if(musicSource.clip.name != "music_ES02"){
                    PlayMusic("music_ES02");
                }
            }else if(EventController.GetInstability >= 60 && EventController.GetInstability < 80){
                if(musicSource.clip.name != "music_ES03"){
                    PlayMusic("music_ES03");
                }
            }else if(EventController.GetInstability >= 80){
                if(musicSource.clip.name != "music_ES04"){
                    PlayMusic("music_ES04");
                }
            }
        }

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

    public void PlaySoundEffect(string name)
    {
        foreach (AudioClip audio in sfxAudio)
        {
            if (audio.name == name)
            {
                sfxSource.clip = audio;
                sfxSource.Play();
                return;
            }
        }
    }
}

