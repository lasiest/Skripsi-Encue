using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float remainingTime;
    [SerializeField] private TaskInformation taskInformation;
    [SerializeField] private TextMeshProUGUI remainingTimeText;
    [SerializeField] private GameObject failedUI;
    [SerializeField] private Button buttonToStartGame;
    private void Start() {
        remainingTime = taskInformation.timeLimit;
        buttonToStartGame.onClick.AddListener(StartTimer);
    }

    private void StartTimer(){
        StartCoroutine(UpdateEverySecond());
    }

    IEnumerator UpdateEverySecond(){
        yield return new WaitForSeconds(1f);
        if(remainingTime > 0){
            remainingTime--;
            remainingTimeText.text = "Time : " + remainingTime + " second(s)"; 
            StartCoroutine(UpdateEverySecond());
        }else{
            Debug.Log("TIme Expired");
            Cursor.lockState = CursorLockMode.None;
            failedUI.SetActive(true);
            FindObjectOfType<FirstPersonModel>().CanTurnHead = false;
            Time.timeScale = 0;
        }
    }

}