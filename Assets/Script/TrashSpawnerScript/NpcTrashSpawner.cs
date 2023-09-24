using System.Collections;
using UnityEngine;

public class NpcTrashSpawner : TrashSpawnerTemplate
{
    protected override float Time => time = Random.Range(5, 20);

    protected override void Reduce() => trashAmount--;

    public override IEnumerator WaitToSpawnFor(float time) 
    {
        yield return new WaitForSeconds(time);
        Spawn();
        if (trashAmount > 0) StartCoroutine(WaitToSpawnFor(Time));
    }
}