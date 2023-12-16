using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public TaskInformation taskInformation;
    public int index;
    public TMP_Text title;
    public TMP_Text desc;
    public Button button;

    private void Start() {
        taskInformation = PlayerManager.Instance.TaskInformation[index];
        title.text = taskInformation.taskTitle;
        desc.text = taskInformation.taskDescription + "\n" + taskInformation.reputationReward + " Reputation & Rp. " + taskInformation.moneyReward;
    }
}