using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : Singleton<GameData>
{
    [Header("Level")]

    [SerializeField] private int currentLevel;

    [SerializeField] private Button levelButton;

    private readonly int totalLevel = 3;

    public float AudioBGMVolume => PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_BGM_VOLUME, defaultValue: 0f);

    public float AudioSFXVolume => PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_SFX_VOLUME, defaultValue: 0f);

    public int LastUnlockedLevel => PlayerPrefs.GetInt(key: PlayerPrefsKey.NEW_LEVEL_DATA, defaultValue: 1);

    public int PlayerMoney => PlayerPrefs.GetInt(key: PlayerPrefsKey.PLAYER_MONEY, defaultValue: 0);

    public float PlayerSpeedMultiplier => PlayerPrefs.GetFloat(PlayerPrefsKey.MOVEMENT_SPEED_MULTIPLIER, defaultValue: 1f);

    public float PlayerStrengthMultiplier => PlayerPrefs.GetFloat(PlayerPrefsKey.PLAYER_STRENGTH_MULTIPLIER, defaultValue: 1f);

    private void Start()
    {
        //ResetAllPlayerPrefs();
        levelButton?.onClick.AddListener(SetCurrentLevel);
    }

    //private void ResetAllPlayerPrefs() => PlayerPrefs.DeleteAll();

    private void SetCurrentLevel() => PlayerPrefs.SetInt(key: PlayerPrefsKey.CURRENT_LEVEL_DATA, value: currentLevel);

    public void UnlockLevel()
    {
        if (currentLevel < totalLevel)
        {
            var nextLevel = currentLevel + 1;
            if (LastUnlockedLevel < nextLevel) PlayerPrefs.SetInt(key: PlayerPrefsKey.NEW_LEVEL_DATA, value: nextLevel);
        }
    }
}