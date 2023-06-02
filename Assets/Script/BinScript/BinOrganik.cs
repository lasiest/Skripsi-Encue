using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinOrganik : MonoBehaviour
{
    SampahInformation sampahInformation;
    public StageManagerScript stageManagerScript;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Trash"){
            sampahInformation = other.gameObject.GetComponent<TrashScript>().sampahInformation;
            if(sampahInformation.tipeSampah == SampahInformation.tipeSampahEnum.None){
                stageManagerScript.increaseScore(50);
                stageManagerScript.increaseTrashNeeded(-1);
                Destroy(other.gameObject);
            }else if(sampahInformation.tipeSampah == SampahInformation.tipeSampahEnum.Organik){
                stageManagerScript.increaseScore(100);
                stageManagerScript.increaseTrashNeeded(-1);
                Destroy(other.gameObject);
            }else if(sampahInformation.tipeSampah == SampahInformation.tipeSampahEnum.Anorganik || sampahInformation.tipeSampah == SampahInformation.tipeSampahEnum.Beracun){
                stageManagerScript.increaseScore(-100);
                stageManagerScript.increaseTrashNeeded(-1);
                Destroy(other.gameObject);
            }
        }
    }
}
