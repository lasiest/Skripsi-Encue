using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public enum CurrentState{
        Play,
        Pause
    }
    [SerializeField]private GameObject _pausePanel;
    [SerializeField]private Button _resumeButton;
    [SerializeField]private Button _backToMenuButton;
    public CurrentState currentState;

    public bool CanBeDone { get; set; } = false;

    private void Start() {
        _pausePanel.SetActive(CanBeDone);
        _resumeButton.onClick.AddListener(UnpauseGame);
        _backToMenuButton.onClick.AddListener(BackToMenu);
    }

    void Update()
    {
        if(CanBeDone && Input.GetKeyDown(KeyCode.Escape)){
            if(currentState == CurrentState.Play){
                PauseGame();
            }else if(currentState == CurrentState.Pause){
                UnpauseGame();
            }
        }
    }

    private void PauseGame(){
        AudioManager.Instance.pauseMusic(AudioManager.Instance.bgmSounds[0].name, true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        currentState = CurrentState.Pause;
        FirstPersonModel.Instance.IsAllowedToMove = false;
    }

    private void UnpauseGame(){
        AudioManager.Instance.pauseMusic(AudioManager.Instance.bgmSounds[0].name, false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        currentState = CurrentState.Play;
        FirstPersonModel.Instance.IsAllowedToMove = true;
    }

    private void BackToMenu(){
        AudioManager.Instance.stopMusic(AudioManager.Instance.bgmSounds[0].name);
        Time.timeScale = 1;
        SceneManager.LoadScene("PC_MainMenu");
    }
}