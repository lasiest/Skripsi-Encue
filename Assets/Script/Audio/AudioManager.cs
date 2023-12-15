using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sounds[] bgmSounds, sfxSounds;
    public AudioSource bgmSource, sfxSource;

    private void awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicVolume(PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME));
        sfxVolume(PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME));
        playMusic(bgmSounds[0].name);
    }

    public void playMusic(string name)
    {
        Sounds bgm = Array.Find(bgmSounds, x => x.name == name);
        if(bgm != null)
        {
            bgmSource.clip = bgm.audioClip;
            bgmSource.Play();
        }
    }

    public void playSFX(string name)
    {
        Sounds sfx = Array.Find(sfxSounds, x => x.name == name);
        if (sfx != null)
        {
            sfxSource.PlayOneShot(sfx.audioClip);
        }
    }

    public void musicVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void sfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
