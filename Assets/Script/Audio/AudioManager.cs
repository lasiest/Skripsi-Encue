using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioMixer audioMixer;

    public Sounds[] bgmSounds, sfxSounds;
    public AudioSource bgmSource, sfxSource;

    public string GRAB_TRASH = "GrabTrash";
    public string THROW_TRASH = "ThrowTrash";

    private string BGM_MIXER = "BgmVolume";
    private string SFX_MIXER = "SfxVolume";

    private void Awake()
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
        setMusicVolume(PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME));
        setSfxVolume(PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME));
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

    public void pauseMusic(string name, Boolean isPause)
    {
        Sounds bgm = Array.Find(bgmSounds, x => x.name == name);
        if (bgm != null)
        {
            if (isPause)
            {
                bgmSource.clip = bgm.audioClip;
                bgmSource.Pause();
            }
            else
            {
                bgmSource.clip = bgm.audioClip;
                bgmSource.UnPause();
            }
        }
    }

    public void stopMusic(string name)
    {
        Sounds bgm = Array.Find(bgmSounds, x => x.name == name);
        if (bgm != null)
        {
            bgmSource.clip = bgm.audioClip;
            bgmSource.Stop();
        }

        Destroy(gameObject);
    }

    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat(BGM_MIXER, Mathf.Log10(volume) * 20);
    }

    public void setSfxVolume(float volume)
    {
        audioMixer.SetFloat(SFX_MIXER, Mathf.Log10(volume) * 20);
    }

}
