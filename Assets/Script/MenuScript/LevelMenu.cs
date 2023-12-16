using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MenuTemplate
{
    [SerializeField] private Button shopButton;

    protected override void Setup()
    {
        shopButton.onClick.AddListener(() => MenuStateMachine.Instance.GoTo(MenuState.Shop));
        GameData.Instance.SetLockedLevel();
    }

    public void LoadScene(GameObject level) => SceneManager.LoadScene(level.name);
}