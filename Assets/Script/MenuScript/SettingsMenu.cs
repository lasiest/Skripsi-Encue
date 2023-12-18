using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MenuTemplate
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Button applyButton;

    private readonly Dictionary<string, float> appliedItems = new();

    private Action<string, float> CallToSetAudioMixer;

    protected override void Setup()
    {
        AssignCallToSetAudioMixer();
        DisableItemBlueprint();
        Apply();
    }

    private void AssignCallToSetAudioMixer() => CallToSetAudioMixer = SetAudioMixerValue;

    private void Apply() => applyButton.onClick.AddListener(() => { foreach (var appliedItem in appliedItems) PlayerPrefs.SetFloat(key: appliedItem.Key, value: appliedItem.Value); });

    protected override void HandleItemValue(Transform populatedItemTransform, MenuItem item)
    {
        if (item.type == MenuItemType.Audio)
        {
            item.value = PlayerPrefs.GetFloat(item.name, 0f);
            var slider = populatedItemTransform.GetChild(2).GetComponent<Slider>();
            slider.wholeNumbers = false;
            slider.minValue = -80f;
            slider.maxValue = 20f;
            slider.value = item.value;
            CallToSetAudioMixer.Invoke(item.name, slider.value);
            slider.onValueChanged.AddListener((value) => CallToSetAudioMixer.Invoke(item.name, value));
        }
    }

    private void SetAudioMixerValue(string exposedParameter, float sliderValue)
    {
        audioMixer.SetFloat(exposedParameter, sliderValue);
        appliedItems[exposedParameter] = sliderValue;
    }
}