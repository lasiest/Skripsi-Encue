using System.Collections;
using UnityEngine;

public class LandTrashSpawner : TrashSpawnerTemplate
{
    protected override Vector3 SpawnPosition => new(Random.Range(-4.5f, 4.5f), 0.07f, Random.Range(-4.5f, 4.5f));

    public override IEnumerator WaitToSpawnFor(float time) 
    {
        GameObject[] allTrash = GameObject.FindGameObjectsWithTag("Trash");
        if (StageManagerScript.Instance.TrashNeeded == 0) StageManagerScript.Instance.StageFinisihed();
        if (allTrash.Length < trashAmount && StageManagerScript.Instance.TrashNeeded > allTrash.Length) Spawn();
        yield return new WaitForSeconds(time);
        StartCoroutine(WaitToSpawnFor(Time));
    }
}