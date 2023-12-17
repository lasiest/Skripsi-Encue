using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MenuTemplate
{
    [SerializeField] private TextMeshProUGUI playerMoney;

    [SerializeField] private List<GameObject> spawnedItemBlueprint; 

    [SerializeField] private TextMeshProUGUI playerStatSpeed;

    [SerializeField] private TextMeshProUGUI playerStatStrength;

    private float PlayerMoney => GameData.Instance.PlayerMoney;

    private float SpeedMultiplier => PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1f);

    private float StrengthMultiplier => PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1f);

    private void DisplayPlayerMoney() => playerMoney.text = PlayerMoney.ToString();

    protected override void Setup()
    {
        DisableItemBlueprint();
        DisplayPlayerMoney();
        PopulateAllItems();
        UpdateMultiplier();
    }

    private string SetPriceOfEach(MenuItem item)
    {
        var price = item.value;
        return item.name switch
        {
            "Speed" => ((int)(price + price * 10 * (SpeedMultiplier - 1))).ToString(),
            "Strength" => ((int)(price + price * 10 * (StrengthMultiplier - 1))).ToString(),
            _ => item.value.ToString()
        };
    }

    protected override void HandleItemValue(Transform populatedItemTransform, MenuItem item)
    {
        populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = SetPriceOfEach(item);
        populatedItemTransform.GetComponent<Button>().onClick.AddListener(() => Purchase(item));
        spawnedItemBlueprint.Add(populatedItemTransform.gameObject);
    }

    private void UpgradeStat(MenuItem shopItem)
    {
        var price = shopItem.value;
        if (shopItem.name == "Speed" && PlayerMoney >= (price + price * 10 * (SpeedMultiplier - 1)))
        {
            PlayerPrefs.SetInt(PlayerPrefsKey.PLAYER_MONEY, (int)(PlayerMoney - (price + price * 10 * (SpeedMultiplier - 1))));
            PlayerPrefs.SetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, SpeedMultiplier + 0.1f);
        }
        else if (shopItem.name == "Strength" && PlayerMoney >= (price + price * 10 * (StrengthMultiplier - 1)))
        {
            PlayerPrefs.SetInt(PlayerPrefsKey.PLAYER_MONEY, (int)(PlayerMoney - (price + price * 10 * (StrengthMultiplier - 1))));
            PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, StrengthMultiplier + 0.1f);
        }
    }

    private void Purchase(MenuItem shopItem)
    {
        if (shopItem.name.In("Speed", "Strength"))
        {
            UpgradeStat(shopItem);
            DisplayPlayerMoney();
            UpdateMultiplier();
            RemoveAllShopItems();
            PopulateAllItems();
        }
    }

    private void UpdateMultiplier()
    {
        playerStatSpeed.text = "Speed Multiplier : " + SpeedMultiplier;
        playerStatStrength.text = "Strength Multiplier : " + StrengthMultiplier;
    }

    private void RemoveAllShopItems()
    {
        foreach (var item in spawnedItemBlueprint)
        {
            Destroy(item);
        }
    }
}