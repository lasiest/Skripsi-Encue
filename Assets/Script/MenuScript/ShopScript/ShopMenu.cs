using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private void GetPlayerMoney() => playerMoney.text = FindObjectOfType<GameData>().PlayerMoney.ToString();

    private void PopulateAllItems()
    {
        
        foreach (var item in shopItems)
        {
            var populatedItemTransform = Instantiate(original: itemBlueprint, parent: itemContent).transform;
            populatedItemTransform.GetComponent<Button>().onClick.AddListener(() => UpgradeStat(item));
            populatedItemTransform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
            populatedItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name.ToString();
            populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.price.ToString(); 
        }
        // var totalShopItems = shopItems.Count;
        // for (int i = 0; i < totalShopItems; i++)
        // {
        //     var populatedItemTransform = Instantiate(original: itemBlueprint, parent: itemContent).transform;
        //     populatedItemTransform.GetComponent<Button>().onClick.AddListener(() => UpgradeStat(shopItems[i]));
        //     populatedItemTransform.GetChild(0).GetComponent<Image>().sprite = shopItems[i].sprite;
        //     populatedItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text = shopItems[i].name.ToString();
        //     populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = shopItems[i].price.ToString();
        // }
    }

    private void RemoveItemBlueprint()
    {
        Destroy(itemBlueprint);
        itemBlueprint = null;
    }

    private void UpgradeStat(ShopItem shopItem){
        if(shopItem.name == "Speed"){
            if(PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_MONEY, 0) > shopItem.price){
                PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_MONEY, PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_MONEY, 0) - shopItem.price);
                PlayerPrefs.SetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1) + 0.1f);
                Setup();                
            }
        }else if(shopItem.name == "Strength"){
            if(PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_MONEY, 0) > shopItem.price){
                PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_MONEY, PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_MONEY, 0) - shopItem.price);
                PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1) + 0.1f);
                Setup();
            }
        }
    }
}