using System.Collections;
using UnityEngine;

public abstract class TrashSpawnerTemplate : MonoBehaviour, ISpawnable
{
    [SerializeField] protected GameObject[] trashPrefab;

    [SerializeField] protected SampahInformation[] sampahInformation;

    [SerializeField] protected float trashAmount;

    [SerializeField] protected float time;

    protected virtual float Time => time;

    protected virtual Vector3 SpawnPosition => transform.position;

    public virtual void Spawn() => Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], SpawnPosition, Quaternion.identity);

    protected void Start() => StartCoroutine(WaitToSpawnFor(Time));

    public abstract IEnumerator WaitToSpawnFor(float time);
}