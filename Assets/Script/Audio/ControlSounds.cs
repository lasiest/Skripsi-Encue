using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSounds : MonoBehaviour
{
    public Slider bgmSlider, sfxSlider;

    private void Start()
    {
        setMusicVolume();
        setSFXVolume();
    }

    private void setMusicVolume()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey.PLAYER_BGM_VOLUME))
        {
            bgmSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME);
        }
        else
        {
            bgmSlider.value = 0.5f;
        }
    }

    private void setSFXVolume()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey.PLAYER_BGM_VOLUME))
        {
            sfxSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME);
        }
        else
        {
            sfxSlider.value = 0.5f;
        }
    }

    public void musicVolume()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME, bgmSlider.value);
    }

    public void sfxVolume()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME, sfxSlider.value);
    }
}
