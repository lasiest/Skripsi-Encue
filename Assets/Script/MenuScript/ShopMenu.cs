using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : ResponsiveMenuTemplate
{
    public override MenuState State => MenuState.Shop;

    [SerializeField] private List<ShopItem> shopItemList = new();

    [SerializeField] private Purchase purchase;

    [SerializeField] private TextMeshProUGUI playerMoney;

    [SerializeField] private List<TextMeshProUGUI> statTMPList;

    protected override void Awake() => DisplayPlayerData();

    protected override void OnEnable()
    {
        itemBlueprint.SetActive(true);
        var totalItems = shopItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = shopItemList[index];
            var newItemObject = Instantiate(original: itemBlueprint, parent: itemContent);
            SetChildComponentsOf(eachItem, fromItemObject: newItemObject);
            itemObjectList.Add(newItemObject);
        }
        itemBlueprint.SetActive(false);
    }

    protected override void SetChildComponentsOf(MenuItem menuItem, GameObject fromItemObject)
    {
        var eachItem = menuItem as ShopItem;
        var fromItemObjectTransform = fromItemObject.transform;
        GetChildComponent<Image>(fromItemObjectTransform, atIndex: 0).sprite = eachItem.sprite;
        GetChildComponent<TextMeshProUGUI>(fromItemObjectTransform, atIndex: 1).text = eachItem.name.ToString();
        SetPriceOf(eachItem, fromItemObjectTransform);
        fromItemObject.GetComponent<Button>().onClick.AddListener(() => { purchase.Buy(eachItem, fromItemObjectTransform, atShopMenu: this, byMultiplier: Multiply(eachItem)); });
    }

    public void DisplayPlayerData()
    {
        DisplayBalance();
        DisplayStatMultiplier();
    }

    private void DisplayBalance() => playerMoney.text = GameData.Instance.PlayerMoney.ToString();

    private void DisplayStatMultiplier()
    {
        var totalItems = shopItemList.Count;
        for (var index = 0; index < totalItems; index++)
        {
            var eachItem = shopItemList[index];
            statTMPList[index].text = eachItem.name + " Multiplier : " + Multiply(eachItem);
        }
    }

    private float Multiply(ShopItem eachItem) => PlayerPrefs.GetFloat(key: eachItem.name, defaultValue: 1f);

    public void SetPriceOf(ShopItem eachItem, Transform fromItemObjectTransform) => GetChildComponent<TextMeshProUGUI>(fromItemObjectTransform, atIndex: 2).text = (eachItem.price * ((int)(10f * (Multiply(eachItem) - 1f)) + 1)).ToString();

    protected override void OnDisable()
    {
        foreach (var shopItemObject in itemObjectList) Destroy(shopItemObject);
        itemObjectList.Clear();
    }
}