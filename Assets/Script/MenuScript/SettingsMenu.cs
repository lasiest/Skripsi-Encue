using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : ResponsiveMenuTemplate
{
    public override MenuState State => MenuState.Settings;

    [SerializeField] private List<SettingsItem> settingItemList = new();

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Button applyButton;

    protected override void Awake() => applyButton.onClick.AddListener(ApplySettings);

    private void ApplySettings()
    {
        var totalItems = settingItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = settingItemList[index];
            var settingsItemObject = itemObjectList[index];
            var slider = GetChildComponent<Slider>(settingsItemObject.transform, atIndex: 2);
            PlayerPrefs.SetFloat(key: eachItem.name, value: slider.value);
        }
    }

    protected override void OnEnable()
    {
        itemBlueprint.SetActive(true);
        var totalItems = settingItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = settingItemList[index];
            var newItemObject = Instantiate(original: itemBlueprint, parent: itemContent);
            SetChildComponentsOf(eachItem, fromItemObject: newItemObject);
            itemObjectList.Add(newItemObject);
        }
        itemBlueprint.SetActive(false);
    }

    protected override void SetChildComponentsOf(MenuItem menuItem, GameObject fromItemObject)
    {
        var eachItem = menuItem as SettingsItem;
        var fromItemObjectTransform = fromItemObject.transform;
        GetChildComponent<Image>(fromItemObjectTransform, atIndex: 0).sprite = eachItem.sprite;
        GetChildComponent<TextMeshProUGUI>(fromItemObjectTransform, atIndex: 1).text = eachItem.name.ToString();
        SetSliderOf(eachItem, fromItemObjectTransform);
    }

    private void SetSliderOf(SettingsItem eachItem, Transform fromItemObjectTransform)
    {
        var slider = GetChildComponent<Slider>(fromItemObjectTransform, atIndex: 2);
        slider.wholeNumbers = false;
        slider.minValue = -80f;
        slider.maxValue = 20f;
        slider.onValueChanged.AddListener((value) => audioMixer.SetFloat(eachItem.name, value));
        ResetValueOf(slider, eachItem);
    }

    private void ResetValueOf(Slider slider, SettingsItem eachItem)
    {
        slider.value = eachItem.volume = PlayerPrefs.GetFloat(key: eachItem.name, defaultValue: 0f);
        audioMixer.SetFloat(eachItem.name, slider.value);
    }

    protected override void OnDisable()
    {
        var totalItems = settingItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = settingItemList[index];
            var settingsItemObject = itemObjectList[index];
            var slider = GetChildComponent<Slider>(settingsItemObject.transform, atIndex: 2);
            ResetValueOf(slider, eachItem);
            Destroy(settingsItemObject);
        }
        itemObjectList.Clear();
    }
}