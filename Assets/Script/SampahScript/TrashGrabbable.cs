using UnityEngine;

public class TrashGrabbable : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Transform grabPoint;

    [SerializeField] private float grabLerpMultiplier;

    private void Start() => rigidBody = GetComponent<Rigidbody>();

    public void BeingGrabbedOrReleased(bool isBeingGrabbed, Transform trashGrabPoint)
    {
        grabPoint = trashGrabPoint;
        rigidBody.useGravity = !isBeingGrabbed;
        rigidBody.isKinematic = isBeingGrabbed;
    }

    private void Update()
    {
        if (grabPoint != null)
        {
            Vector3 smoothedGrabPosition = Vector3.Lerp(transform.position, grabPoint.position, grabLerpMultiplier * Time.deltaTime);
            rigidBody.MovePosition(smoothedGrabPosition);
        }
    }
}