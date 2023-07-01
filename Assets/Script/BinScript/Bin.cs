using UnityEngine;
public class Bin : MonoBehaviour
{
    protected const SampahInformation.tipeSampahEnum tipeSampah = SampahInformation.tipeSampahEnum.Organik;
    protected virtual int SetScore(TrashScript trashScript)
    {
        SampahInformation sampahInformation = trashScript.sampahInformation;
        switch (sampahInformation.tipeSampah)
        {
            case SampahInformation.tipeSampahEnum.None:
                return 50;
            case tipeSampah:
                return 100;
            default:
                return -100;
        }
    }
    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trash")
        {
            StageManagerScript.Instance.Increase?.Invoke(SetScore(other.gameObject.GetComponent<TrashScript>()), -1);
            Destroy(other.gameObject);
        }
    }
}