using System;
using UnityEngine;

public interface IMenuItem
{
    public abstract string Name { get; }
}

public interface IUniqueSpriteItem
{
    public abstract Sprite Sprite { get; }
}

public class MenuItem : IMenuItem
{
    [SerializeField] private string name;

    public string Name { get => name; set => name = value; }
}

public class UniqueSpriteItem : MenuItem, IUniqueSpriteItem
{
    [SerializeField] private Sprite sprite;

    public Sprite Sprite => sprite;
}

[Serializable] public class SettingsItem : UniqueSpriteItem
{
    public float volume;
}

[Serializable] public class ShopItem : UniqueSpriteItem
{
    public int price;
}

[Serializable] public class LevelItem : MenuItem
{
    public int level;

    public bool isUnlocked;
}