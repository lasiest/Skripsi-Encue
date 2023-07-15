using UnityEngine;

public abstract class BinTypeObject : MonoBehaviour
{
    protected abstract SampahInformation.tipeSampahEnum TipeSampah { get; }

    private int SetScore
    (
        SampahInformation trashInfo,
        SampahInformation.tipeSampahEnum none
    )
        => TipeSampah == none
        ? trashInfo.poinSampah / 2
        : (trashInfo.tipeSampah == none
            ? trashInfo.poinSampah / 2 
            : (trashInfo.tipeSampah == TipeSampah 
                ? +trashInfo.poinSampah 
                : -trashInfo.poinSampah
            )
        );

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