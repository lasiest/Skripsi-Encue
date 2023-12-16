using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManagerScript : Singleton<StageManagerScript>
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
        _buttonToStartGame.onClick.AddListener(StageStart);
    }

    private void OnEnable() => Increase += increase;

    private void OnDisable() => Increase -= increase;

    public void BackToMenu() => SceneManager.LoadScene("PC_MainMenu");

    private void increase(int score, int trashNeeded) {
        scoreText.text = "Score :" + (this.score += score);
        if (this.trashNeeded > 0) {
            this.trashNeeded += trashNeeded;
            PlayerManager.Instance.SetTrashCollectedAllTime(trashNeeded * -1);
            trashNeededText.text = this.trashNeeded + " Trash remaining";
        }
    }

    public void StageStart(){
        var pauseController = FindObjectOfType<PauseController>();
        pauseController.CanBeDone = true;
        _player.gameObject.SetActive(true);
        _uiCutscene.gameObject.SetActive(false);
        _openingCamera.gameObject.SetActive(false);
    }

    public void StageFinisihed() {
        AudioManager.Instance.stopMusic(AudioManager.Instance.bgmSounds[0].name);
        finishedPanelGameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        FirstPersonModel.Instance.IsAllowedToMove = false;
        Time.timeScale = 0;
        trashNeededText.text = "There are no more trash";
        var playerManager = PlayerManager.Instance;
        playerManager.SetPlayerReputation(taskInformation.reputationReward + (score / 100));
        playerManager.SetPlayerMoney(taskInformation.moneyReward);
        GameData.Instance.UnlockLevel();
    }
}