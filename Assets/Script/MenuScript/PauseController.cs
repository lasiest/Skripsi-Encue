using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private void Start() {
        _pausePanel.transform.GetChild(0);
        _pausePanel.SetActive(false);
        _resumeButton.onClick.AddListener(UnpauseGame);
        _backToMenuButton.onClick.AddListener(BackToMenu);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(currentState == CurrentState.Play){
                PauseGame();
            }else if(currentState == CurrentState.Pause){
                UnpauseGame();
            }
        }
    }

    private void PauseGame(){
        Cursor.lockState = CursorLockMode.None;
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        currentState = CurrentState.Pause;
        FirstPersonController.Instance._cameraIsLocked = true;
    }

    private void UnpauseGame(){
        Cursor.lockState = CursorLockMode.Locked;
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        currentState = CurrentState.Play;
        FirstPersonController.Instance._cameraIsLocked = false;
    }

    private void BackToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("PC_MainMenu");
    }
}
