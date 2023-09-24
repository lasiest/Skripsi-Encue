using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    private Dictionary<MenuState, MenuTemplate> menuDictionary = new Dictionary<MenuState, MenuTemplate>();

    private Stack<MenuState> visits = new Stack<MenuState>();

#nullable enable
    private MenuTemplate? currentlyActiveMenu;
#nullable disable

    private void Start()
    {
        MenuTemplate[] menus = FindObjectsOfType<MenuTemplate>();
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

    public void Back()
    {
        if (visits.Count < 2) Application.Quit();
        else
        {
            visits.Pop();
            GoTo(visits.Peek(), false);
        }
    }
}