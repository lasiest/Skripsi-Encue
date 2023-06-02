using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public TaskInformation taskInformation;
    public int index;
    public TMP_Text title;
    public TMP_Text desc;
    public Button button;

    private void Start() {
        taskInformation = PlayerManager.Instance.taskInformation[index];
        title.text = taskInformation.taskTitle;
        desc.text = taskInformation.taskDescription + "\n" + taskInformation.reputationReward + " Reputation & Rp. " + taskInformation.moneyReward;
    }
}
