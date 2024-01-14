using UnityEngine;
using UnityEngine.UI;

public abstract class MenuTemplate : MonoBehaviour
{
    public abstract MenuState State { get; }

    [SerializeField] private Button backButton;

    protected abstract void Awake();

    protected void Start() => backButton.onClick.AddListener(MenuStateMachine.Instance.Backtrack);
}