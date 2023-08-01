using UnityEngine;

public class TrashGrabbable : Trash, IGrabbable
{
    private Transform crosshair;

    [SerializeField] 
    private float lerpMultiplier;

    public void BeingGrabbedOrReleased(bool isBeingGrabbed, Transform playerCrosshair)
    {
        crosshair = playerCrosshair;
        rigidBody.useGravity = !isBeingGrabbed;
        rigidBody.isKinematic = isBeingGrabbed;
    }

    private void Update()
    {
        if (crosshair != null)
        {
            Vector3 smoothedGrabPosition = Vector3.Lerp(transform.position, crosshair.position, lerpMultiplier * Time.deltaTime);
            rigidBody.MovePosition(smoothedGrabPosition);
        }
    }
}