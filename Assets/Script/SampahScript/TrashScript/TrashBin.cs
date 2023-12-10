using UnityEngine;

public class TrashBin : Trash
{
    private SampahInformation collectedTrashInfo;

    private readonly SampahInformation.tipeSampahEnum none = SampahInformation.tipeSampahEnum.None;

    private int SetScore() => SampahInformation.tipeSampah == none
        ? +collectedTrashInfo.poinSampah / 2
        : (collectedTrashInfo.tipeSampah == none
            ? +collectedTrashInfo.poinSampah / 2 
            : (collectedTrashInfo.tipeSampah == SampahInformation.tipeSampah
                ? +collectedTrashInfo.poinSampah 
                : -collectedTrashInfo.poinSampah
            )
        );

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            var trashGrabbable = other.gameObject.GetComponent<TrashGrabbable>();
            collectedTrashInfo = trashGrabbable.SampahInformation;
            FindObjectOfType<StageManagerScript>().Increase?.Invoke(SetScore(), -1);
            Destroy(other.gameObject);
        }
    }
}