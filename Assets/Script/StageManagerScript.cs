using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManagerScript : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int trashNeeded;
    public TaskInformation taskInformation;
    public TMP_Text titleText;
    public TMP_Text descText;
    public TMP_Text scoreText;
    public TMP_Text trashNeededText;
    public GameObject buttonGameObject;
    public Button buttonBackToHome;

    private void Awake() {
        taskInformation = PlayerManager.Instance.taskInformation[PlayerManager.Instance.indexCurrentScenarioTask];
        titleText.text = taskInformation.taskTitle;
        descText.text = taskInformation.taskDescription;
        trashNeeded = taskInformation.trashAvailable;
        trashNeededText.text = trashNeeded + " Trash remaining";
        buttonBackToHome.onClick.AddListener(()=>BackToMenu());
        buttonGameObject.SetActive(false);
    }

    public void BackToMenu(){
        SceneManager.LoadScene("PlayerHouse");
    }

    public int getScore(){
        return score;
    }
    public void increaseScore(int value){
        this.score += value;
        scoreText.text = "Score :" + score;
    }

    public int getTrashNeeded(){
        return trashNeeded;
    }
    public void increaseTrashNeeded(int value){
        if(this.trashNeeded > 0){
            this.trashNeeded += value;
            PlayerManager.Instance.SetTrashCollectedAllTime(value * -1);
            trashNeededText.text = trashNeeded + " Trash remaining";
        }
    }

    public void StageFinisihed(){
        buttonGameObject.SetActive(true);
        trashNeededText.text = "There are no more trash";
        PlayerManager.Instance.SetPlayerReputation(taskInformation.reputationReward + (score/100));
        PlayerManager.Instance.SetPlayerMoney(taskInformation.moneyReward); 
    }
}
