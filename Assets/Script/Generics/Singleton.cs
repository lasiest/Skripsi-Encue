using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance => instance ??= FindObjectOfType<T>();

    private void Awake() => Create();

    private void Create()
    {
        instance ??= this as T;
        if (instance != this) Destroy(gameObject);
    }

    private void OnDestroy() => instance = null;
}