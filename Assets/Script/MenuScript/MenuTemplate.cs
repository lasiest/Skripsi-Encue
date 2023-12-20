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

    private readonly List<Transform> populatedItemTransforms = new();

    protected void DisableItemBlueprint() => itemBlueprint.SetActive(false);

    protected void Awake()
    {
        AssignBackButton();
        Setup();
    }

    private void AssignBackButton() => backButton.onClick.AddListener(MenuStateMachine.Instance.Backtrack);

    protected abstract void Setup();

    protected void OnDisable()
    {
        RemoveAllItems();
        EmptyPopulatedItemTransforms();
    }

    private void RemoveAllItems()
    {
        var totalItems = TotalItems;
        for (var index = 0; index < totalItems; index++)
        {
            var populatedItemTransform = populatedItemTransforms[index];
            SetItemValue(populatedItemTransform, item: menuItems[index]);
            Destroy(populatedItemTransform.gameObject);
        }
    }

    protected virtual void SetItemValue(Transform populatedItemTransform, MenuItem item) { }

    private void EmptyPopulatedItemTransforms() => populatedItemTransforms.Clear();

    protected void OnEnable()
    {
        EmptyPopulatedItemTransforms();
        PopulateAllItems();
    }

    private void PopulateAllItems()
    {
        var totalItems = TotalItems;
        for (var index = 0; index < totalItems; index++)
        {
            SetIdOfEach(menuItems[index], index, out MenuItem item);
            Print(item, out Transform populatedItemTransform);
            HandleItemValue(populatedItemTransform, item);
            SetItemValue(populatedItemTransform, item);
        }
    }

    private void SetIdOfEach(MenuItem menuItem, int index, out MenuItem item)
    {
        item = menuItem;
        item.id = index;
    }

    protected T GetChildComponent<T>(Transform populatedItemTransform, int index) => populatedItemTransform.GetChild(index).GetComponent<T>();

    private void Print(MenuItem item, out Transform populatedItemTransform)
    {
        var populatedItem = Instantiate(original: itemBlueprint, parent: itemContent);
        populatedItem.SetActive(true);
        populatedItemTransform = populatedItem.transform;
        GetChildComponent<Image>(populatedItemTransform, index: 0).sprite = item.sprite;
        GetChildComponent<TextMeshProUGUI>(populatedItemTransform, index: 1).text = item.name.ToString();
        populatedItemTransforms.Add(populatedItemTransform);
    }

    protected virtual void HandleItemValue(Transform populatedItemTransform, MenuItem item) { }
}