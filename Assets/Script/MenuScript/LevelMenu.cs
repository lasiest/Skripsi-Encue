using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MenuTemplate
{
    [SerializeField] private Button shopButton;
    [SerializeField] private Button controlsButton;

    protected override void Setup()
    {
        shopButton.onClick.AddListener(() => MenuStateMachine.Instance.GoTo(MenuState.Shop));
        controlsButton.onClick.AddListener(() => MenuStateMachine.Instance.GoTo(MenuState.Controls));
        GameData.Instance.SetLockedLevel();
    }

    public void LoadScene(GameObject level) => SceneManager.LoadScene(level.name);
}