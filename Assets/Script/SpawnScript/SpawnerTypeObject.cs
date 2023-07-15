using System.Collections;
using UnityEngine;

public abstract class SpawnerTypeObject : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] trashPrefab;

    [SerializeField]
    protected SampahInformation[] sampahInformation;

    [SerializeField]
    protected float trashAmount;

    [SerializeField]
    protected float time;

    protected virtual float Time => time;

    protected virtual Vector3 SpawnPosition => transform.position;

    protected void Spawn() 
    {
        GameObject temp = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], SpawnPosition, Quaternion.identity);
        TrashScript trashScript = temp.GetComponent<TrashScript>();
        trashScript.sampahInformation = sampahInformation[Random.Range(0, sampahInformation.Length)];
        Reduce();
    }

    protected virtual void Reduce() { }

    protected void Start() => StartCoroutine(WaitForChecking(Time));

    protected abstract IEnumerator WaitForChecking(float time);
}