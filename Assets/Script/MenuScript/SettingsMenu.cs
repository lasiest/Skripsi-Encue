using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MenuTemplate
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Button applyButton;

    private readonly Dictionary<string, float> appliedItems = new();

    protected override void Setup()
    {
        DisableItemBlueprint();
        Apply();
    }

    private void Apply() => applyButton.onClick.AddListener(() => { foreach (var appliedItem in appliedItems) PlayerPrefs.SetFloat(key: appliedItem.Key, value: appliedItem.Value); });

    protected override void SetItemValue(Transform populatedItemTransform, MenuItem item)
    {
        if (item.type == MenuItemType.Audio)
        {
            var slider = GetChildComponent<Slider>(populatedItemTransform, index: 2);
            item.value = PlayerPrefs.GetFloat(key: item.name, defaultValue: 0f);
            slider.value = item.value;
            SetAudioMixer(exposedParameter: item.name, sliderValue: slider.value);
        }
    }

    private void SetAudioMixer(string exposedParameter, float sliderValue)
    {
        audioMixer.SetFloat(exposedParameter, sliderValue);
        appliedItems[exposedParameter] = sliderValue;
    }

    protected override void HandleItemValue(Transform populatedItemTransform, MenuItem item)
    {
        if (item.type == MenuItemType.Audio)
        {
            var slider = GetChildComponent<Slider>(populatedItemTransform, index: 2);
            slider.wholeNumbers = false;
            slider.minValue = -80f;
            slider.maxValue = 20f;
            slider.onValueChanged.AddListener((value) => SetAudioMixer(exposedParameter: item.name, sliderValue: value));
        }
    }
}