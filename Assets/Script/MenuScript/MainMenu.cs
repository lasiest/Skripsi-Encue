using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuTemplate
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button settingsButton;

    protected override void Setup()
    {
        playButton.onClick.AddListener(() => MenuManager.Instance.GoTo(MenuState.Level));
        settingsButton.onClick.AddListener(() => MenuManager.Instance.GoTo(MenuState.Settings));
    }
}