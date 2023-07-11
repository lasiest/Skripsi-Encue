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

    public int indexCurrentScenarioTask { get; set; }

    private GameObject[] availableTask;
    private TaskInformation[] availableTaskData;

    public TaskInformation[] taskInformation => new TaskInformation[] { };

    public string GetPlayerName() => _playerName;
    public int GetPlayerReputation() => _playerReputation;
    public int GetPlayerMoney() => _playerMoney;
    public int GetTrashCollectedAllTime() => _playerTrashCollectedAllTime;

    public void SetTrashCollectedAllTime(int value) => _playerTrashCollectedAllTime += value;
    public void SetPlayerReputation(int temp) => _playerReputation += temp;
    public void SetPlayerMoney(int temp) => _playerMoney += temp;
    public GameObject[] GetTask() => GameObject.FindGameObjectsWithTag("Task");
    public void SetTask(TaskInformation taskInformation) => availableTaskData[availableTask.Length - 1] = taskInformation;
}