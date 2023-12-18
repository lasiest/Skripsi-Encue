using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuTemplate : MonoBehaviour
{
    [SerializeField] protected MenuState menuState;

    [SerializeField] protected Button backButton;

    [SerializeField] protected Transform itemContent;

    [SerializeField] protected GameObject itemBlueprint;

    [SerializeField] protected List<MenuItem> menuItems = new();

    public MenuState State => menuState;

    protected int TotalItems => menuItems.Count;

    private readonly List<GameObject> populatedItems = new();

    protected void DisableItemBlueprint() => itemBlueprint.SetActive(false);

    protected abstract void Setup();

    protected void Awake()
    {
        AssignBackButton();
        Setup();
    }

    private void AssignBackButton() => backButton.onClick.AddListener(MenuStateMachine.Instance.Backtrack);

    protected void OnDisable() => RemoveAllItems();

    protected void RemoveAllItems()
    {
        foreach (var populatedItem in populatedItems) Destroy(populatedItem);
        populatedItems.Clear();
    }

    protected void OnEnable() => PopulateAllItems();

    protected void PopulateAllItems()
    {
        var totalItems = TotalItems;
        for (var index = 0; index < totalItems; index++)
        {
            SetIdOfEach(menuItems[index], index, out MenuItem item);
            Print(item, out Transform populatedItemTransform);
            HandleItemValue(populatedItemTransform, item);
        }
    }

    private void SetIdOfEach(MenuItem menuItem, int index, out MenuItem item)
    {
        item = menuItem;
        item.id = index;
    }

    private void Print(MenuItem item, out Transform populatedItemTransform)
    {
        var populatedItem = Instantiate(original: itemBlueprint, parent: itemContent);
        populatedItems.Add(populatedItem);
        populatedItem.SetActive(true);
        populatedItemTransform = populatedItem.transform;
        populatedItemTransform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
        populatedItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name.ToString();
    }

    protected virtual void HandleItemValue(Transform populatedItemTransform, MenuItem item) { }
}