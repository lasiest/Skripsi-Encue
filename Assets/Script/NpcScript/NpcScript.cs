using System.Collections;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    [SerializeField]
    private GameObject trashPrefab;

    [SerializeField]
    private SampahInformation[] sampahInformation;

    [SerializeField]
    private float availableTrash;

    private void Start() => StartCoroutine(InstantiateTrash(Random.Range(5, 10)));

    private void Spawn() {
        GameObject temp = Instantiate(trashPrefab, transform.position, Quaternion.identity);
        TrashScript trashScript = temp.GetComponent<TrashScript>();
        trashScript.sampahInformation = sampahInformation[Random.Range(0, sampahInformation.Length)];
        availableTrash--;
    }

    private IEnumerator InstantiateTrash(float wait) {
        yield return new WaitForSeconds(wait);
        Spawn();
        if (availableTrash > 0) StartCoroutine(InstantiateTrash(Random.Range(5, 20)));
    }
}