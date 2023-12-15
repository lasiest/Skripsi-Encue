using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    private IGrabbable anyGrabbable;
    [SerializeField] private Transform crosshair;
    private GameObject target;

    public GameObject Target => target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (anyGrabbable == null)
            {
                if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hitInfo, maxDistance, layerMask))
                {
                    anyGrabbable = hitInfo.collider.GetComponent<IGrabbable>();
                    anyGrabbable.BeingGrabbedOrReleased(true, crosshair);
                    target = hitInfo.transform.gameObject;
                    AudioManager.Instance.playSFX(AudioManager.Instance.GRAB_TRASH);
                }
            }
            else
            {
                anyGrabbable.BeingGrabbedOrReleased(false, null);
                anyGrabbable = null;
                target = null;
                AudioManager.Instance.playSFX(AudioManager.Instance.THROW_TRASH);
            }
        }
    }
}