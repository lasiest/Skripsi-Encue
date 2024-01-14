using System.Collections.Generic;
using UnityEngine;

public abstract class ResponsiveMenuTemplate : MenuTemplate
{
    [SerializeField] protected Transform itemContent;

    [SerializeField] protected GameObject itemBlueprint;

    protected readonly List<GameObject> itemObjectList = new();

    protected T GetChildComponent<T>(Transform fromItemObjectTransform, int atIndex) => fromItemObjectTransform.GetChild(atIndex).GetComponent<T>();

    protected abstract void SetChildComponentsOf(MenuItem eachItem, GameObject fromItemObject);

    protected abstract void OnEnable();

    protected abstract void OnDisable();
}