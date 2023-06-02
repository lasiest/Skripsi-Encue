using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public GameObject trashPrefab;
    public SampahInformation[] sampahInformation;
    public float availabeTrash;

    private void Start() {
        int random = Random.Range(5, 10);
        StartCoroutine(instantiateTrash(random));
    } 

    void Spawn(){
        GameObject temp = Instantiate (trashPrefab, transform.position, Quaternion.identity);
        TrashScript trashScript = temp.GetComponent<TrashScript>();
        trashScript.sampahInformation = sampahInformation[Random.Range(0, sampahInformation.Length)]; 
        availabeTrash--;
    }
    IEnumerator instantiateTrash(float wait){
        yield return new WaitForSeconds(wait);
        Spawn();
        if(availabeTrash > 0){
            int random = Random.Range(5, 20);
            StartCoroutine(instantiateTrash(random));
        }
    }
}
