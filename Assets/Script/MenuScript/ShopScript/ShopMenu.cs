using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MenuTemplate
{
    [SerializeField] private TextMeshProUGUI playerMoney;

    [SerializeField] private Transform itemContent;

    [SerializeField] private GameObject itemBlueprint;

    [SerializeField] private List<ShopItem> shopItems = new();

    protected override void Setup()
    {
        GetPlayerMoney();
        PopulateAllItems();
        RemoveItemBlueprint();
    }

    private void GetPlayerMoney() => playerMoney.text = GameData.Instance.PlayerMoney.ToString();

    private void PopulateAllItems()
    {
        var totalShopItems = shopItems.Count;
        for (int i = 0; i < totalShopItems; i++)
        {
            var populatedItemTransform = Instantiate(original: itemBlueprint, parent: itemContent).transform;
            populatedItemTransform.GetChild(0).GetComponent<Image>().sprite = shopItems[i].sprite;
            populatedItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopItems[i].name.ToString();
            populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = shopItems[i].price.ToString();
        }
    }

    private void RemoveItemBlueprint()
    {
        Destroy(itemBlueprint);
        itemBlueprint = null;
    }
}