using TMPro;
using UnityEngine;

public class PlayerMoneyScript : MonoBehaviour
{
    public TMP_Text reputationText;
    public TMP_Text moneyText;

    private void Start() {
        var playerManager = PlayerManager.Instance;
        reputationText.text = "Rep : " + playerManager.GetPlayerReputation();
        moneyText.text = "Money : " + playerManager.GetPlayerMoney();
    }
}