using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : Singleton<MenuStateMachine>
{
    private readonly Dictionary<MenuState, MenuTemplate> menuDictionary = new();

    private readonly Stack<MenuState> visits = new();

#nullable enable
    private MenuTemplate? currentlyActiveMenu;
#nullable disable

    private void Awake()
    {
        var menus = FindObjectsOfType<MenuTemplate>();
        foreach(var menu in menus)
        {
            menuDictionary.Add(menu.State, menu);
            menu.gameObject.SetActive(false);
        }
        GoTo(MenuState.Main);
    }

    public void GoTo(MenuState nextMenuState, bool stateIsNew = true)
    {
        if (menuDictionary.ContainsKey(nextMenuState))
        {
            if (stateIsNew) visits.Push(nextMenuState);
            currentlyActiveMenu?.gameObject.SetActive(false);
            currentlyActiveMenu = menuDictionary[nextMenuState];
            currentlyActiveMenu.gameObject.SetActive(true);
        }
    }

    public void Backtrack()
    {
        if (visits.Count < 2) QuitApplication();
        else
        {
            visits.Pop();
            GoTo(visits.Peek(), false);
        }
    }

    private void QuitApplication() => Application.Quit();
}