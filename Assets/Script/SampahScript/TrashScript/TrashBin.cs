using System.Collections;
using UnityEngine;

public class TrashBin : Trash
{
    private SampahInformation collectedTrashInfo;

    private readonly SampahInformation.tipeSampahEnum none = SampahInformation.tipeSampahEnum.None;
    [SerializeField]private GameObject popUpBerhasil;
    [SerializeField]private GameObject popUpGagal;

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
            if(sampahInformation.tipeSampah == collectedTrashInfo.tipeSampah){
                StartCoroutine(ShowPopUp(true));
            }else{
                StartCoroutine(ShowPopUp(false));
            }
            StageManagerScript.Instance.Increase?.Invoke(SetScore(), -1);
            Destroy(other.gameObject);
        }
    }

    IEnumerator ShowPopUp(bool isPopUpBerhasil){
        if(isPopUpBerhasil){
            popUpBerhasil.SetActive(true);
        }else{
            popUpGagal.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        popUpBerhasil.SetActive(false);
        popUpGagal.SetActive(false);
    }
}