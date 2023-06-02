using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinMixed : MonoBehaviour
{
    public StageManagerScript stageManagerScript;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Trash"){
            stageManagerScript.increaseScore(50);
            stageManagerScript.increaseTrashNeeded(-1);
            Destroy(other.gameObject);
        }
    }
}
