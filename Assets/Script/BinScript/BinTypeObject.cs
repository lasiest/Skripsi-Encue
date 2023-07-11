using UnityEngine;

public abstract class BinTypeObject : MonoBehaviour
{
    protected abstract SampahInformation.tipeSampahEnum TipeSampah { get; }

    private int SetScore
    (
        SampahInformation sampahInformation, 
        SampahInformation.tipeSampahEnum none
    ) 
    => (sampahInformation.tipeSampah != none || TipeSampah != none) 
    ? (sampahInformation.tipeSampah == TipeSampah ? 100 : -100) 
    : 50;

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trash")
        {
            TrashScript trashScript = other.gameObject.GetComponent<TrashScript>();
            StageManagerScript.Instance.Increase?.Invoke
            (
                SetScore
                (
                    trashScript.sampahInformation, 
                    SampahInformation.tipeSampahEnum.None
                ), 
                -1
            );
            Destroy(other.gameObject);
        }
    }
}