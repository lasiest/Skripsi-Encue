using UnityEngine;

public class Purchase : MonoBehaviour
{
    private int Balance => GameData.Instance.PlayerMoney;

    private int CalculatePriceOf(ShopItem eachItem, float byMultiplier) => eachItem.price * ((int)(10f * (byMultiplier - 1f)) + 1);

    public void Buy(ShopItem eachItem, Transform fromItemObjectTransform, ShopMenu atShopMenu, float byMultiplier)
    {
        var price = CalculatePriceOf(eachItem, byMultiplier);
        if (Balance >= price)
        {
            ReduceBalanceBy(price);
            UpgradeStatFrom(eachItem, byMultiplier);
            atShopMenu.SetPriceOf(eachItem, fromItemObjectTransform);
            atShopMenu.DisplayPlayerData();
        }
    }

    private void ReduceBalanceBy(int price) => PlayerPrefs.SetInt(key: PlayerPrefsKey.PLAYER_MONEY, value: Balance - price);

    private void UpgradeStatFrom(ShopItem eachItem, float byMultiplier) => PlayerPrefs.SetFloat(key: eachItem.Name, value: byMultiplier + 0.1f);
}