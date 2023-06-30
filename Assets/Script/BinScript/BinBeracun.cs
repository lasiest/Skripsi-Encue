using UnityEngine;

public class BinBeracun : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Trash") {
            SampahInformation sampahInformation = other.gameObject.GetComponent<TrashScript>().sampahInformation;
            switch(sampahInformation.tipeSampah)
            {
                case SampahInformation.tipeSampahEnum.None:
                    StageManagerScript.Instance.increaseScore(50);
                    break;
                case SampahInformation.tipeSampahEnum.Beracun:
                    StageManagerScript.Instance.increaseScore(100);
                    break;
                default:
                    StageManagerScript.Instance.increaseScore(-100);
                    break;
            }
            StageManagerScript.Instance.increaseTrashNeeded(-1);
            Destroy(other.gameObject);
        }
    }
}