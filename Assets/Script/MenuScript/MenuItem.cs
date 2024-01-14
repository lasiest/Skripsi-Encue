using System;
using UnityEngine;

public class MenuItem
{
    public Sprite sprite;

    public string name;
}

[Serializable] public class SettingsItem : MenuItem
{
    public float volume;
}

[Serializable] public class ShopItem : MenuItem
{
    public int price;
}