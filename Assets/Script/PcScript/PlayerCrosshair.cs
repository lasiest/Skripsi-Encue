using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private IGrabbable anyGrabbable;

    [SerializeField] private Transform crosshair;
    private GameObject currentGameObject;

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
                    currentGameObject = hitInfo.transform.gameObject;
                }
            }
            else
            {
                anyGrabbable.BeingGrabbedOrReleased(false, null);
                anyGrabbable = null;
                currentGameObject = null;
            }
        }
    }

    public GameObject GetGrabbedObject(){
        return currentGameObject;
    }
}