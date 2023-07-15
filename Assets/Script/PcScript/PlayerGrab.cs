using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform trashGrabPoint;

    private TrashGrabbable trashGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (trashGrabbable == null)
            {
                if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hitInfo, maxDistance, layerMask))
                {
                    trashGrabbable = hitInfo.collider.GetComponent<TrashGrabbable>();
                    trashGrabbable.BeingGrabbedOrReleased(true, trashGrabPoint);
                }
            }
            else
            {
                trashGrabbable.BeingGrabbedOrReleased(false, null);
                trashGrabbable = null;
            }
        }
    }
}