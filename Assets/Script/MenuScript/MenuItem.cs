using System;
using UnityEngine;

[Serializable] public class MenuItem
{
    public int id;

    public Sprite sprite;

    public string name;

    public MenuItemType type;

    public float value;

    public bool interactable;
}