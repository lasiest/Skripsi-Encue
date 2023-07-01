using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefab;
    public SampahInformation[] sampahInformation;
    public float numberOfTrash;
    public float checkingTime;

    private void Start() => StartCoroutine(WaitForChecking(checkingTime));

    void Spawn () {    
        float spawnPointX = Random.Range(-4.5f, 4.5f);
        float spawnPointZ = Random.Range(-4.5f, 4.5f);
        Vector3 spawnPosition = new Vector3(spawnPointX, 0.07f, spawnPointZ);
        int random = Random.Range(0, 1);
        GameObject temp = Instantiate (trashPrefab[Random.Range(0, trashPrefab.Length)], spawnPosition, Quaternion.identity);
        TrashScript trashScript = temp.GetComponent<TrashScript>();
        trashScript.sampahInformation = sampahInformation[Random.Range(0, sampahInformation.Length)]; 
    }

    IEnumerator WaitForChecking(float time){
        GameObject[] temp;
        temp = GameObject.FindGameObjectsWithTag("Trash");
        if (StageManagerScript.Instance.TrashNeeded == 0) {
            StageManagerScript.Instance.StageFinisihed();
        }
        if (temp.Length < numberOfTrash && StageManagerScript.Instance.TrashNeeded > temp.Length) {
            Spawn();
        }
        yield return new WaitForSeconds(time);
        Debug.Log("Called");
        StartCoroutine(WaitForChecking(checkingTime));
    }
}