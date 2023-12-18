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

    private readonly int totalLevel = 3;

    public int PlayerMoney => PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0);

    private void Start() => Setup();

    private void Setup()
    {
        //ResetAllPlayerPrefs();
        SelectCurrentScene();
    }

    //private void ResetAllPlayerPrefs() => PlayerPrefs.DeleteAll();

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

    //private int GetCurrentLevelData() => PlayerPrefs.GetInt(key: PlayerPrefsKey.CURRENT_LEVEL_DATA);

    private int GetNewLevelData() => PlayerPrefs.GetInt(key: PlayerPrefsKey.NEW_LEVEL_DATA, defaultValue: 1);

    public void SetLockedLevel()
    {
        for (int i = 0; i < GetNewLevelData(); i++)
        {
            availableLevels[i].GetComponent<Button>().interactable = true;
            availableLevels[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void SetCurrentLevel() => PlayerPrefs.SetInt(key: PlayerPrefsKey.CURRENT_LEVEL_DATA, value: currentLevel);

    public void UnlockLevel()
    {
        if (currentLevel < totalLevel)
        {
            var nextLevel = currentLevel + 1;
            if (GetNewLevelData() < nextLevel)
            {
                PlayerPrefs.SetInt(key: PlayerPrefsKey.NEW_LEVEL_DATA, value: nextLevel);
            }
        }
    }
}