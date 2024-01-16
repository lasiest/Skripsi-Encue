using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : ResponsiveMenuTemplate
{
    public override MenuState State => MenuState.Level;

    [SerializeField] private List<LevelItem> levelItemList = new();

    [SerializeField] private Button shopButton;

    [SerializeField] private Button controlsButton;

    protected override void Awake()
    {
        var menuStateMachine = MenuStateMachine.Instance;
        shopButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Shop));
        controlsButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Controls));
    }

    protected override void OnEnable()
    {
        itemBlueprint.SetActive(true);
        var totalItems = levelItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = levelItemList[index];
            var newItemObject = Instantiate(original: itemBlueprint, parent: itemContent);
            eachItem.level = index + 1;
            eachItem.Name = eachItem.level.ToString();
            SetChildComponentsOf(eachItem, fromItemObject: newItemObject);
            itemObjectList.Add(newItemObject);
        }
        itemBlueprint.SetActive(false);
    }

    protected override void SetChildComponentsOf(IMenuItem menuItem, GameObject fromItemObject)
    {
        var eachItem = menuItem as LevelItem;
        var fromItemObjectTransform = fromItemObject.transform;
        var eachItemLevel = eachItem.level;
        var eachLevelIsUnlocked = eachItem.isUnlocked = eachItemLevel <= GameData.Instance.LastUnlockedLevel;
        var button = fromItemObject.GetComponent<Button>();
        button.interactable = eachLevelIsUnlocked;
        if (eachLevelIsUnlocked)
        {
            var padlockImage = GetChildComponent<RectTransform>(fromItemObjectTransform, atIndex: 0).gameObject;
            Destroy(padlockImage);
            button.onClick.AddListener(() => SceneManager.LoadScene(eachItemLevel));
        }
        fromItemObject.GetComponentInChildren<TextMeshProUGUI>().text = eachItem.Name;
    }

    protected override void OnDisable()
    {
        foreach (var levelItemObject in itemObjectList) Destroy(levelItemObject);
        itemObjectList.Clear();
    }
}