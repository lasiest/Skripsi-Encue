using UnityEngine;
using UnityEngine.UI;

public abstract class MenuTemplate : MonoBehaviour
{
    [SerializeField] 
    protected MenuState menuState;

    public MenuState State => menuState;

    [SerializeField] 
    protected Button backButton;

    protected abstract void Setup();

    protected void Start()
    {
        Setup();
        backButton.onClick.AddListener(() => MenuManager.Instance.Back());
    }
}