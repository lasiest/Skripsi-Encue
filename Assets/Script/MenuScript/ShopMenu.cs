using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MenuTemplate
{
    [SerializeField] private TextMeshProUGUI playerMoney;

    [SerializeField] private List<TextMeshProUGUI> statTMPs;

    private int Balance => GameData.Instance.PlayerMoney;

    private void DisplayBalance() => playerMoney.text = Balance.ToString();

    protected override void Setup()
    {
        DisableItemBlueprint();
        DisplayBalance();
        DisplayStatMultiplier();
    }

    protected override void HandleItemValue(Transform populatedItemTransform, MenuItem item)
    {
        //item.type = item.id % 2 == 0 ? MenuItemType.Stat : MenuItemType.Consumable;
        DisplayPrice(populatedItemTransform, item);
        populatedItemTransform.GetComponent<Button>().onClick.AddListener(() => Purchase(populatedItemTransform, item));
    }

    private float GetMultiplierOfEach(MenuItem item) => PlayerPrefs.GetFloat(key: item.name, defaultValue: 1f);

    private int GetPriceOfEach(MenuItem item) => (int)item.value + (int)item.value * (int)(10f * (GetMultiplierOfEach(item) - 1f));

    private void DisplayPrice(Transform populatedItemTransform, MenuItem item) => GetChildComponent<TextMeshProUGUI>(populatedItemTransform, index: 2).text = GetPriceOfEach(item).ToString();

    private void Purchase(Transform populatedItemTransform, MenuItem item)
    {
        if (CanBuy(item))
        {
            UpdateBalanceAfterBuy(item);
            ApplyUpgradeFrom(item);
            DisplayPrice(populatedItemTransform, item);
            DisplayBalance();
        }
    }

    private bool CanBuy(MenuItem item) => Balance >= GetPriceOfEach(item);

    private void UpdateBalanceAfterBuy(MenuItem item) => PlayerPrefs.SetInt(key: PlayerPrefsKey.PLAYER_MONEY, value: Balance - GetPriceOfEach(item));

    private void ApplyUpgradeFrom(MenuItem item)
    {
        switch(item.type)
        {
            case MenuItemType.Stat:
                UpgradeMultiplierAfterBuy(item, byValue: 0.1f);
                DisplayStatMultiplier();
                break;
            default: 
                break;
        }
    }

    private void UpgradeMultiplierAfterBuy(MenuItem item, float byValue) => PlayerPrefs.SetFloat(key: item.name, value: GetMultiplierOfEach(item) + byValue);

    private void DisplayStatMultiplier()
    {
        var totalItems = TotalItems;
        for (var index = 0; index < totalItems; index++)
        {
            var item = menuItems[index];
            statTMPs[index].text = item.name + " Multiplier : " + GetMultiplierOfEach(item);
        }
    }
}