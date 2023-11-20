using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public enum CurrentScene{
        MainMenu,
        Level
    }
    public CurrentScene currentScene;

    [Header("Main Menu")]
    [SerializeField]private GameObject[] availableLevels;

    [Header("Level")]
    [SerializeField]private int currentLevel;
    [SerializeField]private GameObject levelButton;

    private void Start() {
        if(currentScene == CurrentScene.MainMenu){
            SetLockedLevel(LoadCurrentLevelData());
        }
        if(currentScene == CurrentScene.Level){
            levelButton.GetComponent<Button>().onClick.AddListener(SetLevel);
        }
    }

    public int LoadCurrentLevelData(){
        return PlayerPrefs.GetInt("CurrentLevelData", 1);
    }

    public void SetLockedLevel(int temp){
        for(int i = 0; i < temp; i++){
            availableLevels[i].GetComponent<Button>().interactable = true;
            availableLevels[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SetLevel(){
        if(LoadCurrentLevelData() < currentLevel){
            PlayerPrefs.SetInt("CurrentLevelData", currentLevel);
        }
    }
}
