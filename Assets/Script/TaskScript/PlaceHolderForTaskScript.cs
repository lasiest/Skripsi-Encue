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
    private PlayerManager playerManager;

    private void Start() {
        playerManager = PlayerManager.Instance;
        taskInformation = playerManager.TaskInformation;
        taskAvailable = playerManager.GetTask();
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
        taskAvailable = playerManager.GetTask();
    }

    public void InstantiateTask(){
        GameObject temp = Instantiate(taskPrefab, gameObject.transform);
        int random = Random.Range(0, taskInformation.Length);
        TaskManager taskManager = temp.GetComponent<TaskManager>();
        taskManager.index = random;
        Debug.Log(taskManager.button);
        taskManager.button.onClick.AddListener(()=>AssignScene(taskInformation[taskManager.index]));
        playerManager.GetTask();
        playerManager.SetTask(taskInformation[taskManager.index]);
    }

    public void AssignScene(TaskInformation taskInformation){
        playerManager.IndexCurrentScenarioTask = taskInformation.taskIndex;
        Debug.Log(taskInformation.sceneName.ToString());
        SceneManager.LoadScene(taskInformation.sceneName.ToString());
    }
}
