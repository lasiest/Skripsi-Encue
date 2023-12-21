using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuTemplate
{
    [SerializeField] private Button playButton;

    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;

    protected override void Setup()
    {
        var menuStateMachine = MenuStateMachine.Instance;
        playButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Level));
        settingsButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Settings));
        creditsButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Credits));
    }
}