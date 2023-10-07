using UnityEngine;

public class PlayerCrosshair : Singleton<PlayerCrosshair>
{
    private Transform mainCamera;
    private float maxDistance;
    private LayerMask layerMask;
    private IGrabbable anyGrabbable;
    private Transform crosshair;
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
                }
            }
            else
            {
                anyGrabbable.BeingGrabbedOrReleased(false, null);
                anyGrabbable = null;
                target = null;
            }
        }
    }
}