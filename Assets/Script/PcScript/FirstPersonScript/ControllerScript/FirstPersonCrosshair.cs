using UnityEngine;

public class FirstPersonCrosshair : MonoBehaviour
{
    [SerializeField] private Transform crosshair;

    [SerializeField] private FirstPersonInput input;

    [SerializeField] private Transform mainCamera;

    [SerializeField] private float maxDistance = 2f;

    [SerializeField] private LayerMask layerMask;

    private IGrabbable anyGrabbable;

    public GameObject Target { get; private set; }

    private void Update()
    {
        if (input.GetKeyDownE)
        {
            if (anyGrabbable == null)
            {
                if (Physics.Raycast(mainCamera.position, mainCamera.forward, out RaycastHit hitInfo, maxDistance, layerMask))
                {
                    anyGrabbable = hitInfo.collider.GetComponent<IGrabbable>();
                    anyGrabbable.BeingGrabbedOrReleased(true, crosshair);
                    Target = hitInfo.transform.gameObject;
                    AudioManager.Instance.playSFX(AudioManager.Instance.GRAB_TRASH);
                }
            }
            else
            {
                anyGrabbable.BeingGrabbedOrReleased(false, null);
                anyGrabbable = null;
                Target = null;
                AudioManager.Instance.playSFX(AudioManager.Instance.THROW_TRASH);
            }
        }
    }
}