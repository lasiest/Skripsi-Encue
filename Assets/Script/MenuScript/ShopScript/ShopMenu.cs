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
    [SerializeField] private List<GameObject> spawnedItemBlueprint; 
    [SerializeField] private TextMeshProUGUI playerStatSpeed;
    [SerializeField] private TextMeshProUGUI playerStatStrength;

    protected override void Setup()
    {
        GetPlayerMoney();
        PopulateAllItems();
        UpdateMultiplier();
        //RemoveItemBlueprint();
    }

    private void GetPlayerMoney() => playerMoney.text = GameData.Instance.PlayerMoney.ToString();

    private void PopulateAllItems()
    {
        foreach (var item in shopItems)
        {
            var populatedItemTransform = Instantiate(original: itemBlueprint, parent: itemContent).transform;
            populatedItemTransform.GetComponent<Button>().onClick.AddListener(() => UpgradeStat(item));
            populatedItemTransform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
            populatedItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name.ToString();
            if(item.name == "Speed"){
                populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ((int)(item.price + item.price * 10 * (PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1) - 1))).ToString();
            }else if(item.name == "Strength"){
                populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ((int)(item.price + item.price * 10 * (PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1) - 1))).ToString();
            }else{
                populatedItemTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.price.ToString();
            }
            populatedItemTransform.transform.gameObject.SetActive(true);

            spawnedItemBlueprint.Add(populatedItemTransform.gameObject);
        }
    }

    private void RemoveItemBlueprint()
    {
        Destroy(itemBlueprint);
        itemBlueprint = null;
    }

    private void RemoveAllShopItems()
    {
        foreach (var item in spawnedItemBlueprint)
        {
            Destroy(item);
        }
    }

    private void UpgradeStat(ShopItem shopItem){
        if(shopItem.name == "Speed"){
            if(PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) >= (shopItem.price + shopItem.price * 10 * (PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1) - 1))){
                PlayerPrefs.SetInt(PlayerPrefsKey.PLAYER_MONEY, (int)(PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) - (shopItem.price + shopItem.price * 10 * (PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1) - 1))));
                PlayerPrefs.SetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1) + 0.1f);
                GetPlayerMoney();   
                UpdateMultiplier();  
                RemoveAllShopItems();    
                PopulateAllItems();      
            }
        }else if(shopItem.name == "Strength"){
            if(PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) >= (shopItem.price + shopItem.price * 10 * (PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1) - 1))){
                PlayerPrefs.SetInt(PlayerPrefsKey.PLAYER_MONEY, (int)(PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0) - (shopItem.price + shopItem.price * 10 * (PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1) - 1))));
                PlayerPrefs.SetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1) + 0.1f);
                GetPlayerMoney();
                UpdateMultiplier();
                RemoveAllShopItems();
                PopulateAllItems();
            }
        }
    }

    private void UpdateMultiplier(){
        playerStatSpeed.text = "Speed Multiplier : " + PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, 1);
        playerStatStrength.text = "Strength Multiplier : " + PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, 1);
    }
}