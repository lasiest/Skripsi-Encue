using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuTemplate
{
    [SerializeField] private Button playButton;

    [SerializeField] private Button settingsButton;

    protected override void Setup()
    {
        var menuStateMachine = transform.parent.GetComponent<MenuStateMachine>();
        playButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Level));
        settingsButton.onClick.AddListener(() => menuStateMachine.GoTo(MenuState.Settings));
    }
}