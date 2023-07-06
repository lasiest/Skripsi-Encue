using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trashPrefab;

    [SerializeField]
    private SampahInformation[] sampahInformation;

    [SerializeField]
    private float numberOfTrash;

    [SerializeField]
    private float checkingTime;

    private void Start() => StartCoroutine(WaitForChecking(checkingTime));

    private void Spawn () {
        float spawnPointX = Random.Range(-4.5f, 4.5f);
        float spawnPointZ = Random.Range(-4.5f, 4.5f);
        Vector3 spawnPosition = new Vector3(spawnPointX, 0.07f, spawnPointZ);
        GameObject temp = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)], spawnPosition, Quaternion.identity);
        TrashScript trashScript = temp.GetComponent<TrashScript>();
        trashScript.sampahInformation = sampahInformation[Random.Range(0, sampahInformation.Length)];
    }

    private IEnumerator WaitForChecking(float time) {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Trash");
        if (StageManagerScript.Instance.TrashNeeded == 0) StageManagerScript.Instance.StageFinisihed();
        if (temp.Length < numberOfTrash && StageManagerScript.Instance.TrashNeeded > temp.Length) Spawn();
        yield return new WaitForSeconds(time);
        StartCoroutine(WaitForChecking(checkingTime));
    }
}