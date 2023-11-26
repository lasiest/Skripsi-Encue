using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : Singleton<GameData>
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
    [SerializeField] private Button levelButton;

    private const string currentLevelData = "CurrentLevelData";
    private const string newLevelData = "NewLevelData";

    private void Start() => Setup();

    private void Setup()
    {
        //TestLockedLevel();
        SelectCurrentScene();
    }

    //private void TestLockedLevel() => PlayerPrefs.DeleteAll();

    private void SelectCurrentScene()
    {
        switch (currentScene)
        {
            case CurrentScene.MainMenu:
                //levelButton.onClick.AddListener(LoadLevel);
                break;
            case CurrentScene.Level:
                levelButton.onClick.AddListener(SetCurrentLevel);
                break;
        }
    }

    //private void LoadLevel() => SceneManager.LoadScene(GetCurrentLevelData() - 1);

    //private int GetCurrentLevelData() => PlayerPrefs.GetInt(key: currentLevelData);

    private int GetNewLevelData() => PlayerPrefs.GetInt(key: newLevelData, defaultValue: 1);

    public void SetLockedLevel()
    {
        for (int i = 0; i < GetNewLevelData(); i++)
        {
            availableLevels[i].GetComponent<Button>().interactable = true;
            availableLevels[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void SetCurrentLevel() => PlayerPrefs.SetInt(key: currentLevelData, value: currentLevel);

    public void UnlockLevel()
    {
        var nextLevel = currentLevel + 1;
        if (GetNewLevelData() < nextLevel)
        {
            PlayerPrefs.SetInt(key: newLevelData, value: nextLevel);
        }
    }
}