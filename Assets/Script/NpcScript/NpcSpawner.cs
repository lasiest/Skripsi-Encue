using System.Collections;
using UnityEngine;

public class NpcSpawner : SpawnerTypeObject
{
    protected override float Time => time = Random.Range(5, 20);

    protected override void Reduce() => trashAmount--;

    protected override IEnumerator WaitForChecking(float time) 
    {
        yield return new WaitForSeconds(time);
        Spawn();
        if (trashAmount > 0) StartCoroutine(WaitForChecking(Time));
    }
}