using System.Collections;
using UnityEngine;

public class LandTrashSpawner : TrashSpawnerTemplate
{
    private StageManagerScript stageManager;

    protected override Vector3 SpawnPosition => new(Random.Range(-4.5f, 4.5f), 0.07f, Random.Range(-4.5f, 4.5f));

    private void Setup() => stageManager = FindObjectOfType<StageManagerScript>();

    protected override void Start()
    {
        Setup();
        base.Start();
    }

    public override IEnumerator WaitToSpawnFor(float time) 
    {
        var allTrash = GameObject.FindGameObjectsWithTag("Trash");
        if (stageManager.TrashNeeded == 0) stageManager.StageFinisihed();
        if (allTrash.Length < trashAmount && stageManager.TrashNeeded > allTrash.Length) Spawn();
        yield return new WaitForSeconds(time);
        StartCoroutine(WaitToSpawnFor(Time));
    }
}