using System.Collections;
using UnityEngine;

public class TrashSpawner : SpawnerTypeObject
{
    protected override Vector3 SpawnPosition => new(Random.Range(-4.5f, 4.5f), 0.07f, Random.Range(-4.5f, 4.5f));

    protected override IEnumerator WaitForChecking(float time) 
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Trash");
        if (StageManagerScript.Instance.TrashNeeded == 0) StageManagerScript.Instance.StageFinisihed();
        if (temp.Length < trashAmount && StageManagerScript.Instance.TrashNeeded > temp.Length) Spawn();
        yield return new WaitForSeconds(time);
        StartCoroutine(WaitForChecking(Time));
    }
}