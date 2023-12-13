using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MenuTemplate
{
    [SerializeField] private Button shopButton;

    protected override void Setup()
    {
        shopButton.onClick.AddListener(() => transform.parent.GetComponent<MenuStateMachine>().GoTo(MenuState.Shop));
        FindObjectOfType<GameData>().SetLockedLevel();
    }

    public void LoadScene(GameObject level) => SceneManager.LoadScene(level.name);
}