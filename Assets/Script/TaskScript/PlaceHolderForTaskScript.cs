using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceHolderForTaskScript : MonoBehaviour
{
    public TaskInformation[] taskInformation;
    public GameObject[] taskAvailable;
    public GameObject taskPrefab;
    private void Start() {
        taskInformation = PlayerManager.Instance.taskInformation;
        taskAvailable = PlayerManager.Instance.GetTask();
        for(int i = taskAvailable.Length; i < 2; i++){
            InstantiateTask();
        }
        // if(taskAvailable.Length == 0){
        //     for(int i = 0; i < 2; i++){
        //         InstantiateTask();
        //     }
        // }else if(taskAvailable.Length < 2){
        //     InstantiateTask();
        // }
        taskAvailable = PlayerManager.Instance.GetTask();
    }

    public void InstantiateTask(){
        GameObject temp = Instantiate(taskPrefab, gameObject.transform);
        int random = Random.Range(0, taskInformation.Length);
        TaskManager taskManager = temp.GetComponent<TaskManager>();
        taskManager.index = random;
        Debug.Log(taskManager.button);
        taskManager.button.onClick.AddListener(()=>AssignScene(taskInformation[taskManager.index]));
        PlayerManager.Instance.GetTask();
        PlayerManager.Instance.SetTask(taskInformation[taskManager.index]);
    }

    public void AssignScene(TaskInformation taskInformation){
        PlayerManager.Instance.indexCurrentScenarioTask = taskInformation.taskIndex;
        Debug.Log(taskInformation.sceneName.ToString());
        SceneManager.LoadScene(taskInformation.sceneName.ToString());
    }
}
