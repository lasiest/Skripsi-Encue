using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MenuTemplate
{
    [SerializeField]
    private Button shopButton;

    protected override void Setup() => shopButton.onClick.AddListener(() => MenuManager.Instance.GoTo(MenuState.Shop));
}