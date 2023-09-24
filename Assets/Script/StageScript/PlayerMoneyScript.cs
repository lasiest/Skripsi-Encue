using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyScript : MonoBehaviour
{
    public TMP_Text reputationText;
    public TMP_Text moneyText;

    private void Start() {
        reputationText.text = "Rep : " + PlayerManager.Instance.GetPlayerReputation();
        moneyText.text = "Money : " + PlayerManager.Instance.GetPlayerMoney();
    }
}
