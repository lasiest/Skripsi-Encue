using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private string _playerName;

    [SerializeField] private int _playerReputation;

    [SerializeField] private int _playerMoney;

    [SerializeField] private int _playerTrashCollectedAllTime;

    public int IndexCurrentScenarioTask { get; set; }

    private readonly GameObject[] availableTask;

    private readonly TaskInformation[] availableTaskData;

    private readonly TaskInformation[] taskInformation = new TaskInformation[] { };

    public TaskInformation[] TaskInformation => taskInformation;

    public string GetPlayerName() => _playerName;

    public int GetPlayerReputation() => _playerReputation;

    public int GetPlayerMoney() => _playerMoney;

    public int GetTrashCollectedAllTime() => _playerTrashCollectedAllTime;

    public void SetTrashCollectedAllTime(int value) => _playerTrashCollectedAllTime += value;

    public void SetPlayerReputation(int temp) => _playerReputation += temp;

    public void SetPlayerMoney(int temp)
    {
        _playerMoney = FindObjectOfType<GameData>().PlayerMoney;
        PlayerPrefs.SetInt(key: PlayerPrefsKey.PLAYER_MONEY, value: _playerMoney + temp);
    }

    public GameObject[] GetTask() => GameObject.FindGameObjectsWithTag("Task");

    public void SetTask(TaskInformation taskInformation) => availableTaskData[availableTask.Length - 1] = taskInformation;
}