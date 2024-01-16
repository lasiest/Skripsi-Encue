using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlSounds : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public Slider bgmSlider, sfxSlider;

    private string BGM_MIXER = "BGM";
    private string SFX_MIXER = "SFX";

    private void Awake()
    {
        bgmSlider.onValueChanged.AddListener(setBgmVolume);
        bgmSlider.onValueChanged.AddListener(setSfxVolume);
    }

    private void Start() => GetVolume();

    private void GetVolume()
    {
        var gameData = GameData.Instance;
        bgmSlider.value = gameData.AudioBGMVolume;
        sfxSlider.value = gameData.AudioSFXVolume;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME, bgmSlider.value);
        PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME, sfxSlider.value);
    }

    public void setBgmVolume(float volume)
    {
        audioMixer.SetFloat(BGM_MIXER, Mathf.Log10(volume)*20);
    }

    public void setSfxVolume(float volume)
    {
        audioMixer.SetFloat(SFX_MIXER, Mathf.Log10(volume) * 20);
    }
}
