using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : ResponsiveMenuTemplate
{
    public override MenuState State => MenuState.Settings;

    [SerializeField] private List<SettingsItem> settingsItemList = new();

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Button applyButton;

    protected override async void Awake()
    {
        applyButton.onClick.AddListener(ApplySettings);
        await Task.Delay(TimeSpan.FromSeconds(0.01f));
        foreach (var eachItem in settingsItemList) SetVolumeOf(eachItem);
    }

    private void ApplySettings()
    {
        var totalItems = settingsItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = settingsItemList[index];
            var settingsItemObject = itemObjectList[index];
            var slider = GetChildComponent<Slider>(settingsItemObject.transform, atIndex: 2);
            PlayerPrefs.SetFloat(key: eachItem.Name, value: eachItem.volume = slider.value);
        }
    }

    private float SetVolumeOf(SettingsItem eachItem)
    {
        eachItem.volume = PlayerPrefs.GetFloat(eachItem.Name, defaultValue: 0f);
        audioMixer.SetFloat(eachItem.Name, value: eachItem.volume);
        return eachItem.volume;
    }

    protected override void OnEnable()
    {
        itemBlueprint.SetActive(true);
        var totalItems = settingsItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = settingsItemList[index];
            var newItemObject = Instantiate(original: itemBlueprint, parent: itemContent);
            SetChildComponentsOf(eachItem, fromItemObject: newItemObject);
            itemObjectList.Add(newItemObject);
        }
        itemBlueprint.SetActive(false);
    }

    protected override void SetChildComponentsOf(IMenuItem menuItem, GameObject fromItemObject)
    {
        var eachItem = menuItem as SettingsItem;
        var fromItemObjectTransform = fromItemObject.transform;
        GetChildComponent<Image>(fromItemObjectTransform, atIndex: 0).sprite = eachItem.Sprite;
        GetChildComponent<TextMeshProUGUI>(fromItemObjectTransform, atIndex: 1).text = eachItem.Name.ToString();
        SetSliderOf(eachItem, fromItemObjectTransform);
    }

    private void SetSliderOf(SettingsItem eachItem, Transform fromItemObjectTransform)
    {
        var slider = GetChildComponent<Slider>(fromItemObjectTransform, atIndex: 2);
        slider.wholeNumbers = false;
        slider.minValue = -80f;
        slider.maxValue = 20f;
        slider.value = SetVolumeOf(eachItem);
        slider.onValueChanged.AddListener((value) => audioMixer.SetFloat(eachItem.Name, eachItem.volume = value));
    }

    protected override void OnDisable()
    {
        var totalItems = settingsItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = settingsItemList[index];
            var settingsItemObject = itemObjectList[index];
            SetVolumeOf(eachItem);
            Destroy(settingsItemObject);
        }
        itemObjectList.Clear();
    }
}