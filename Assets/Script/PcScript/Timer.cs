using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float remainingTime;
    [SerializeField] private TaskInformation taskInformation;
    [SerializeField] private TextMeshProUGUI remainingTimeText;
    private void Start() {
        remainingTime = taskInformation.timeLimit;
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
            Time.timeScale = 0;
        }
    }

}
