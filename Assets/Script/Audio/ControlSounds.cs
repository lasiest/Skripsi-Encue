using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlSounds : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public Slider bgmSlider, sfxSlider;

    private string BGM_MIXER = "BGM";
    private string SFX_MIXER = "SFX";

    private void Start()
    {
        getBgmVolume();
        getSfxVolume();
    }

    private void Awake()
    {
        bgmSlider.onValueChanged.AddListener(setBgmVolume);
        bgmSlider.onValueChanged.AddListener(setSfxVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME, bgmSlider.value);
        PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME, sfxSlider.value);
    }

    private void getBgmVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME, 1f);
    }

    private void getSfxVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME, 1f);
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
