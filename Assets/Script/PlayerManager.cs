using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    private string _playerName;

    [SerializeField]
    private int _playerReputation;

    [SerializeField]
    private int _playerMoney;

    [SerializeField]
    private int _playerTrashCollectedAllTime;
    [SerializeField]
    public int indexCurrentScenarioTask;
    public GameObject[] availableTask;
    public TaskInformation[] availableTaskData;
    public TaskInformation[] taskInformation;

    public string GetPlayerName(){
        return _playerName;
    }

    public int GetPlayerReputation(){
        return _playerReputation;
    }

    public int GetPlayerMoney(){
        return _playerMoney;
    }
    public int GetTrashCollectedAllTme(){
        return _playerTrashCollectedAllTime;
    }
    public void SetTrashCollectedAllTime(int value){
        _playerTrashCollectedAllTime += value;
    }
    public void SetPlayerReputation(int temp){
        _playerReputation += temp;
    }
    public void SetPlayerMoney(int temp){
        _playerMoney += temp;
    }
    public GameObject[] GetTask(){
        availableTask = GameObject.FindGameObjectsWithTag("Task");
        return availableTask;
    }

    public void SetTask(TaskInformation taskInformation){
        availableTaskData[availableTask.Length-1] = taskInformation;
    }
}