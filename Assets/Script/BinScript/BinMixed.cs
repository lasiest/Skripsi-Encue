using UnityEngine;

public class BinMixed : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Trash") {
            StageManagerScript.Instance.increaseScore(50);
            StageManagerScript.Instance.increaseTrashNeeded(-1);
            Destroy(other.gameObject);
        }
    }
}