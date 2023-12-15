using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManagerScript : MonoBehaviour
{
    [SerializeField] private int score;

    public int Score => score;

    [SerializeField] private int trashNeeded;

    public int TrashNeeded => trashNeeded;

    [SerializeField] private int timeLimit;

    public int TimeLimit => timeLimit;

    [SerializeField] private TaskInformation taskInformation;

    public Action<int, int> Increase { get; private set; }

    [Header("UI")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text trashNeededText;
    [SerializeField] private GameObject finishedPanelGameObject;
    [SerializeField] private Button buttonBackToHome;
    
    [Header("Required Component To Start Game")]
    [SerializeField] private GameObject _openingCamera;
    [SerializeField] private GameObject _player;
    [SerializeField] private Button _buttonToStartGame;
    [SerializeField] private GameObject _uiCutscene;

    private PlayerManager _playerManager;
    private FirstPersonModel player;
    private GameData _dataLevel;

    private void Awake() {
        //taskInformation = PlayerManager.Instance.taskInformation[PlayerManager.Instance.indexCurrentScenarioTask];
        titleText.text = taskInformation.taskTitle;
        descText.text = taskInformation.taskDescription;
        trashNeeded = taskInformation.trashAvailable;
        timeLimit = taskInformation.timeLimit;
        trashNeededText.text = trashNeeded + " Trash remaining";
        buttonBackToHome.onClick.AddListener(BackToMenu);
        finishedPanelGameObject.SetActive(false);
    }

    private void Start() {
        _playerManager = _player.GetComponent<PlayerManager>();
        player = _player.GetComponent<FirstPersonModel>();
        _dataLevel = FindObjectOfType<GameData>();
        _buttonToStartGame.onClick.AddListener(StageStart);
    }

    private void OnEnable() => Increase += increase;

    private void OnDisable() => Increase -= increase;

    public void BackToMenu() => SceneManager.LoadScene("PC_MainMenu");

    private void increase(int score, int trashNeeded) {
        scoreText.text = "Score :" + (this.score += score);
        if (this.trashNeeded > 0) {
            this.trashNeeded += trashNeeded;
            _playerManager.SetTrashCollectedAllTime(trashNeeded * -1);
            trashNeededText.text = this.trashNeeded + " Trash remaining";
        }
    }

    public void StageStart(){
        _player.gameObject.SetActive(true);
        _uiCutscene.gameObject.SetActive(false);
        _openingCamera.gameObject.SetActive(false);
    }

    public void StageFinisihed() {
        AudioManager.Instance.stopMusic(AudioManager.Instance.bgmSounds[0].name);
        finishedPanelGameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        player.CanTurnHead = false;
        Time.timeScale = 0;
        trashNeededText.text = "There are no more trash";
        _playerManager.SetPlayerReputation(taskInformation.reputationReward + (score / 100));
        _playerManager.SetPlayerMoney(taskInformation.moneyReward);
        _dataLevel.UnlockLevel();
    }
}