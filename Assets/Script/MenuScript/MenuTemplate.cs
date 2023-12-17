using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuTemplate : MonoBehaviour
{
    [SerializeField] protected MenuState menuState;

    public MenuState State => menuState;

    [SerializeField] protected Button backButton;

    [SerializeField] protected Transform itemContent;

    [SerializeField] protected GameObject itemBlueprint;

    [SerializeField] protected List<MenuItem> menuItems = new();

    protected List<GameObject> populatedItems = new();

    protected void DisableItemBlueprint() => itemBlueprint.SetActive(false);

    protected abstract void Setup();

    private void GoBack() => backButton.onClick.AddListener(MenuStateMachine.Instance.Backtrack);

    protected void OnEnable ()
    {
        Setup();
        GoBack();
    }

    protected void PopulateAllItems()
    {
        foreach (var item in menuItems)
        {
            Print(item, out Transform populatedItemTransform);
            HandleItemValue(populatedItemTransform, item);
        }
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

    protected void OnDisable() => RemoveAllItems();

    private void RemoveAllItems()
    {
        foreach (var populatedItem in populatedItems)
        {
            Destroy(populatedItem);
        }
    }
}