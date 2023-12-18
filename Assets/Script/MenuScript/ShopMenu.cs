using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MenuTemplate
{
    [SerializeField] private TextMeshProUGUI playerMoney;

    [SerializeField] private List<TextMeshProUGUI> statTMPs;

    private int PlayerMoney => GameData.Instance.PlayerMoney;

    private void DisplayPlayerMoney() => playerMoney.text = PlayerMoney.ToString();

    protected override void Setup()
    {
        DisableItemBlueprint();
        DisplayPlayerMoney();
        UpdateStatMultiplier();
    }

    protected override void HandleItemValue(Transform populatedItemTransform, MenuItem item)
    {
        item.type = item.id % 2 == 0 ? MenuItemType.Stat : MenuItemType.Consumable;
        populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GetPriceOfEach(item).ToString();
        populatedItemTransform.GetComponent<Button>().onClick.AddListener(() => Purchase(item));
    }

    private float GetMultiplierOfEach(MenuItem item) => PlayerPrefs.GetFloat(key: item.name, defaultValue: 1f);

    private int GetPriceOfEach(MenuItem item) => (int)item.value + (int)item.value * (int)(10f * (GetMultiplierOfEach(item) - 1f));

    private void UpgradeStatFromEach(MenuItem item)
    {
        if (item.type == MenuItemType.Stat && PlayerMoney >= GetPriceOfEach(item))
        {
            PlayerPrefs.SetInt(key: PlayerPrefsKey.PLAYER_MONEY, value: PlayerMoney - GetPriceOfEach(item));
            PlayerPrefs.SetFloat(key: item.name, value: GetMultiplierOfEach(item) + 0.1f);
        }
    }

    private void Purchase(MenuItem item)
    {
        UpgradeStatFromEach(item);
        DisplayPlayerMoney();
        UpdateStatMultiplier();
        RemoveAllItems();
        PopulateAllItems();
    }

    private void UpdateStatMultiplier()
    {
        var totalItem = TotalItems;
        for (var index = 0; index < totalItem; index += 2)
        {
            var item = menuItems[index];
            statTMPs[index / 2].text = item.name + " Multiplier : " + GetMultiplierOfEach(item);
        }
    }
}