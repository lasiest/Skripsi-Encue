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
    [SerializeField] private TextMeshProUGUI playerStatSpeed;
    [SerializeField] private TextMeshProUGUI playerStatStrength;

    protected override void Setup()
    {
        GetPlayerMoney();
        PopulateAllItems();
        UpdateMultiplier();
        //RemoveItemBlueprint();
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
            populatedItemTransform.transform.gameObject.SetActive(true);
        }
    }

    private void RemoveItemBlueprint()
    {
        Destroy(itemBlueprint);
        itemBlueprint = null;
    }

    private void UpgradeStat(ShopItem shopItem){
        if(shopItem.name == "Speed"){
            if(PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) >= shopItem.price){
                PlayerPrefs.SetInt(PlayerPrefsKey.PLAYER_MONEY, PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) - shopItem.price);
                PlayerPrefs.SetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1) + 0.1f);
                GetPlayerMoney();   
                UpdateMultiplier();            
            }
        }else if(shopItem.name == "Strength"){
            if(PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) >= shopItem.price){
                PlayerPrefs.SetInt(PlayerPrefsKey.PLAYER_MONEY, PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) - shopItem.price);
                PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1) + 0.2f);
                GetPlayerMoney();
                UpdateMultiplier();
            }
        }
    }

    private void UpdateMultiplier(){
        playerStatSpeed.text = "Speed Multiplier : " + PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1);
        playerStatStrength.text = "Strength Multiplier : " + PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1);
    }
}